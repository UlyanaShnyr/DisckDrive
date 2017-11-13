using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Data.Entity;

namespace WcfService1
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
    }

    public class MyDrive : DbContext
    {
        public MyDrive(string con) : base(con) { }
        public virtual DbSet<User> Users { get; set; }
    }
}