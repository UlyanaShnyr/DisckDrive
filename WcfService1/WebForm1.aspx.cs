﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WcfService1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Proxy.Service1Client client = new Proxy.Service1Client();
            var fileName = client.Upload(FileUpload1.FileContent);
            Session["file"] = fileName;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Proxy.Service1Client client = new Proxy.Service1Client();
            var stream = client.Download(Session["file"].ToString());
            StreamReader reader = new StreamReader(stream);
            Response.Write(reader.ReadToEnd());

        }

    }
}