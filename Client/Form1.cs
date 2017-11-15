using Client.ServiceReference1;
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
        public  User _User;
        FileSystemWatcher fw;


        public Form1()
        {
            InitializeComponent();
            logiIn log = new logiIn(this);
            log.ShowDialog();
            this.Hide();
            if(!Directory.Exists(basePath + "\\" + _User.Login))
                Directory.CreateDirectory(basePath + "\\" + _User.Login);


            currentPath = basePath + "\\" + _User.Login;
          
            fw = new FileSystemWatcher(currentPath);
            fw.IncludeSubdirectories = true;
            fw.EnableRaisingEvents = true;

            fw.Changed += Fw_Changed;
            fw.Created += Fw_Created;

            fw.Renamed += Fw_Renamed;

            // создаем элементы меню
            ToolStripMenuItem renameMenuItem = new ToolStripMenuItem("Rename");
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Delete");
            ToolStripMenuItem addFolderMenuItem = new ToolStripMenuItem("AddFolder");
            ToolStripMenuItem addFileMenuItem = new ToolStripMenuItem("AddFile");


            Client.Synhronization sync = new Client.Synhronization();
            //sync.Synh(basePath,currentPath);
            // добавляем элементы в меню
            contextMenuStrip1.Items.AddRange(new[] { renameMenuItem, deleteMenuItem, addFolderMenuItem, addFileMenuItem });

            // ассоциируем контекстное меню с текстовым полем
            textBox1.ContextMenuStrip = contextMenuStrip1;

            // устанавливаем обработчики событий для меню
            renameMenuItem.Click += renameMenuItem_Click;
            deleteMenuItem.Click += deleteMenuItem_Click;
            addFolderMenuItem.Click += addFolderMenuItem_Click;
            addFileMenuItem.Click += addFileMenuItem_Click;

            SyncFolder();
            SyncFile();

            SetListView(currentPath);
        }

        void SyncFile()
        {

            List<string> allfiles = new List<string>();
            List<ServerFiles> serverFile = client.SearchFiles(currentPath.Remove(0, basePath.Length)).ToList();
            GetAllFiles(currentPath, allfiles);

            for (int i = 0; i < serverFile.Count(); i++)
            {
                if (!allfiles.Contains(basePath + "\\" + serverFile[i].name))
                {
                    if (serverFile[i].files.Length > 0) File.WriteAllBytes(basePath + "\\" + serverFile[i].name, serverFile[i].files);

                }
            }

            for (int i = 0; i < allfiles.Count; i++)
            {
                if (!serverFile.Select(file=>file.name).Contains(allfiles[i].Remove(0, basePath.Length)))
                {
                    File.Delete(allfiles[i]);
                }
            }
        }

        void GetAllFiles(string path, List<string> all)
        {
            if (Directory.GetFiles(path).Length > 0)
                all.AddRange(Directory.GetFiles(path));


            for (int i = 0; i < Directory.GetDirectories(path).Length; i++)
            {
                GetAllFiles(Directory.GetDirectories(path)[i], all);
            }
        }

        void SyncFolder()
        {
            List<string> all = new List<string>();
            List<string> serverFolder = client.SerchDirectories().ToList();
            GetAllFolders(currentPath, all);

            for(int i=0; i < serverFolder.Count(); i++)
            {
                if (!all.Contains(basePath + "\\" + serverFolder[i]))
                {
                    Directory.CreateDirectory(basePath+"\\"+serverFolder[i]);
                   
                }
            }

            for (int i=0; i<all.Count;i++)
            {
                if (!serverFolder.Contains(all[i].Remove(0,basePath.Length)))
                {
                    Directory.Delete(all[i],true);
                }
            }


        }

         void GetAllFolders(string path,List<string> all)
        {
            if (Directory.GetDirectories(path).Length > 0)
                all.AddRange(Directory.GetDirectories(path));


            for (int i = 0; i < Directory.GetDirectories(path).Length; i++)
            {
                GetAllFolders(Directory.GetDirectories(path)[i], all);
            }
        }


          //  CheckChange(basePath);
        

        private void Fw_Renamed(object sender, RenamedEventArgs e)
        {
           //SetListView(currentPath);
            MessageBox.Show("gfdg");
        }

        private void Fw_Created(object sender, FileSystemEventArgs e)
        {
            //SetListView(currentPath);
            MessageBox.Show("Create");
        }

        private void Fw_Changed(object sender, FileSystemEventArgs e)
        {
            MessageBox.Show("Change");
           // SetListView(currentPath);
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
           
            client.Delete(path.Remove(0, basePath.Length));
            if (Directory.Exists(path))
                Directory.Delete(currentPath+"\\"+ listView1.SelectedItems[0].Text,true);
            else
            {
                File.Delete(currentPath + "\\" + listView1.SelectedItems[0].Text);
            }
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
