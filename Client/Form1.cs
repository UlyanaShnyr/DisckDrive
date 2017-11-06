using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        string basePath = @"D:\root";
        public Form1()
        {
            InitializeComponent();
            SetListView(basePath);
           
        }

        void SetListView(string path)
        {
            listView1.Items.Clear();
            foreach (var item in client.ReadAll(path))
            {
                listView1.Items.Add(item);

            }
            
        }

         int LastItemOfPath(string path)
        {
           // SetListView(path);
            int lenth = listView1.Items.Count;
            return lenth;

        }
      

        private void buttonDownload_Click(object sender, EventArgs e)
        {
          
            client.Download("");
        }

        private void button1Create_Click(object sender, EventArgs e)
        {
            
            client.CreateFolder(basePath+"/test3");
            SetListView(basePath);
            listView1.SelectedItems[LastItemOfPath(basePath)-1].BeginEdit();
           

        }
    }
}
