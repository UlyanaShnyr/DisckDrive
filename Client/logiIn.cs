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

namespace Client
{
    public partial class logiIn : Form
    {
        public logiIn()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=ULYANA;Initial Catalog=MyDrive;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlDataAdapter adapt = new SqlDataAdapter("Select Count(*) From DataLogin Where Username ='" + textBoxLogin.Text + "' and Password ='" + textBoxPassword.Text + "'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
            }
            else
            {
                MessageBox.Show("Please Cheack your Login Name and Password");
            }
        }
    }
}
