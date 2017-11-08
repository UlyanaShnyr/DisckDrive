using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        string basePath = @"D:\root\Client";
        string currentPath;

        
        public Form1()
        {
            InitializeComponent();
            SetListView(basePath);
            currentPath = basePath;

            // создаем элементы меню
            ToolStripMenuItem renameMenuItem = new ToolStripMenuItem("Rename");
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            ToolStripMenuItem addFolderMenuItem = new ToolStripMenuItem("AddFolder");
            ToolStripMenuItem addFileMenuItem = new ToolStripMenuItem("AddFile");

            // добавляем элементы в меню
            contextMenuStrip1.Items.AddRange(new[] { renameMenuItem, deleteMenuItem, addFolderMenuItem, addFileMenuItem });

            // ассоциируем контекстное меню с текстовым полем
            textBox1.ContextMenuStrip = contextMenuStrip1;

            // устанавливаем обработчики событий для меню
            renameMenuItem.Click += renameMenuItem_Click;
            deleteMenuItem.Click += deleteMenuItem_Click;
            addFolderMenuItem.Click += addFolderMenuItem_Click;
            addFileMenuItem.Click += addFileMenuItem_Click;

          //  CheckChange(basePath);
        }

        void CheckChange(string path)
        {
           // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watch = new FileSystemWatcher();
            watch.Path = Path.GetDirectoryName(basePath);
            /* Watch for changes in LastAccess and LastWrite times, and
          the renaming of files or directories. */
            watch.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watch.Filter = "";

            // Add event handlers.
            watch.Changed += new FileSystemEventHandler(OnChanged);

        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            WatcherChangeTypes wct = e.ChangeType;
            MessageBox.Show(wct.ToString());
        }



        void renameMenuItem_Click(object sender, EventArgs e)
        {
            listView1.SelectedItems[0].BeginEdit();
        }


        void deleteMenuItem_Click(object sender, EventArgs e)
        {
            
            var path =currentPath+"\\"+ listView1.SelectedItems[0].Text;
            MessageBox.Show(path.Remove(0, currentPath.Length));
            client.Delete(path.Remove(0, currentPath.Length));
                Directory.Delete(currentPath+"\\"+ listView1.SelectedItems[0].Text);
                SetListView(currentPath);
        }


        void addFolderMenuItem_Click(object sender, EventArgs e)
        {           
            string path = Path.GetRandomFileName();
            Directory.CreateDirectory(currentPath + "\\" + path);
            SetListView(currentPath);
                        int index = -1;
            for (var item = 0; item < listView1.Items.Count; item++)
            {
                if (listView1.Items[item].Text == path)
                {
                    index = item;
                    client.CreateFolder(currentPath.Remove(0, basePath.Length) + "\\" + listView1.Items[item].Text);
                }
            }
            if (index != -1)
                listView1.Items[index].BeginEdit();
            else MessageBox.Show("Error");

        }
        void addFileMenuItem_Click(object sender, EventArgs e)
        {
            string path = Path.GetRandomFileName();
            File.Create(currentPath + "/" +path);            
            SetListView(currentPath);
            int index = -1;
            for (var item = 0; item < listView1.Items.Count; item++)
            {
                if (listView1.Items[item].Text == path)
                {
                    index = item;
                    client.CreateFile(currentPath.Remove(0, basePath.Length) + "\\" + listView1.Items[item].Text);
                }
            }
            if (index != -1)
                listView1.Items[index].BeginEdit();
            else MessageBox.Show("Error");
        }

        void SetListView(string path)
        {
            listView1.Items.Clear();
            //  foreach (var item in client.ReadAll(path))
            List<string> items = Directory.GetDirectories(path).ToList();
            items.AddRange(Directory.GetFiles(path));

          foreach(var item in items)
            {
                listView1.Items.Add(item.Split('\\').Last());
            }
            currentPath = path;
            textBox1.Text = currentPath;           
        }

         int LastItemOfPath(string path)
        {
            int lenth = listView1.Items.Count;
            return lenth;
        }      


        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string path = currentPath + "\\" + listView1.SelectedItems[0].Text;
            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
             SetListView(path);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {            
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            var path = currentPath + "\\" + listView1.Items[e.Item].Text;            
            if (e.Label == null) { return; }
            if (Directory.Exists(path))
            {
                Directory.Move(path, currentPath + "\\" + e.Label);
            }
            else
            {
                File.Move(path, currentPath + "\\" + e.Label);
            }
            client.Rename(path.Remove(0, basePath.Length), (currentPath + "\\" + e.Label).Remove(0, basePath.Length));
        }

        private void buttonCreateFile_Click(object sender, EventArgs e)
        {
            string path = Path.GetRandomFileName();
            File.Create(currentPath + "/" + path);
            SetListView(currentPath);
            int index = -1;
            for (var item = 0; item < listView1.Items.Count; item++)
            {
                if (listView1.Items[item].Text == path) index = item;
                client.CreateFile(listView1.Items[item].Text);
            }
            if (index != -1)
                listView1.Items[index].BeginEdit();
            else MessageBox.Show("Error");
        }

        private void button1CreateFolder_Click(object sender, EventArgs e)
        {
            string path = Path.GetRandomFileName();
            Directory.CreateDirectory(currentPath + "/" + path);
            SetListView(currentPath);           
            int index = -1;
            for (var item = 0; item < listView1.Items.Count; item++)
            {
                if (listView1.Items[item].Text == path) index = item;
                client.CreateFolder(listView1.Items[item].Text);
            }
            if (index != -1)
                listView1.Items[index].BeginEdit();
            else MessageBox.Show("Error");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            client.Delete(listView1.SelectedItems[0].Text.Remove(0, currentPath.Length));
            Directory.Delete(currentPath + "/" + listView1.SelectedItems[0].Text);
            SetListView(currentPath);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if(currentPath!=basePath)
            SetListView(Path.GetDirectoryName(currentPath));
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
