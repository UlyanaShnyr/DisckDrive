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
        //ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        string basePath = @"D:\root";
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



        }

        void renameMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        void deleteMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
                if (item.Selected)
                    listView1.Items.Remove(item);
           
        }
        void addFolderMenuItem_Click(object sender, EventArgs e)
        {

            string path = Path.GetRandomFileName();
            Directory.CreateDirectory(currentPath + "/" + path);
            SetListView(currentPath);

            //client.CreateFolder(basePath+"/test3");
            //SetListView(basePath);

            int index = -1;

            for (var item = 0; item < listView1.Items.Count; item++)
            {
                if (listView1.Items[item].Text == path) index = item;
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
                if (listView1.Items[item].Text == path) index = item;
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
           // SetListView(path);
            int lenth = listView1.Items.Count;
            return lenth;

        }
      

        private void buttonDownload_Click(object sender, EventArgs e)
        {
          
          //  client.Download("");
        }

        private void button1Create_Click(object sender, EventArgs e)
        {
            string path = Path.GetRandomFileName();
            Directory.CreateDirectory(currentPath + "/" + path);
            SetListView(currentPath);

            //client.CreateFolder(basePath+"/test3");
            //SetListView(basePath);

            int index = -1;

            for(var item= 0;item< listView1.Items.Count;item++)
            {
                if (listView1.Items[item].Text == path) index = item;
            }
            if (index != -1)
                listView1.Items[index].BeginEdit();

            else MessageBox.Show("Error");

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
            //string path = currentPath + "\\" + listView1.SelectedItems[0].Text;
            //if (File.Exists(path)) { 
            //textBox1.Text = currentPath + "\\" + listView1.SelectedItems[0].Text;
            //}
            //textBox1.Text = currentPath;
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            var path = currentPath + "\\" + listView1.Items[e.Item].Text;
            
            if (e.Label == null) { return; }
            if (Directory.Exists(path))
            {
                Directory.Move(path, currentPath + "\\" + e.Label);
            }
        }
    }
}
