using Client.ServiceReference1;
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
    public partial class Registration : Form
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
         string currentPath;
        string basePath = @"D:\root\Client";
        Form1 main;

        public Registration(Form1 main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabelGoToTheLoginForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            //logiIn log = new logiIn();
            //log.Show();
        }

        private void ButtonRegistration_Click(object sender, EventArgs e)
        {
            User user = new User()

            {
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text
            };

            
            string answer = client.Regist(user);
            if (answer == textBoxLogin.Text) this.Hide();
            else MessageBox.Show(answer);
           // logiIn log = new logiIn();
            //log.Show();

            //string path = textBoxLogin.Text;
            //Directory.CreateDirectory(currentPath + "\\" + path);


          
        }
    }
}
