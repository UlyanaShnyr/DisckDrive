using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Client.ServiceReference1;

namespace Client
{
    public partial class logiIn : Form
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        Form1 main;
        public User _User;
        string basePath = @"D:\root\Client";


        public logiIn(Form1 main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {           

            this.Hide();
            var tmp = client.Log(textBoxLogin.Text, textBoxPassword.Text);

            main._User = tmp;      

            main.Show();

        }

        private void linkLabelGoTotheRegistrationForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.Hide();
            Registration reg = new Registration(main);
            reg.Show();
        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
