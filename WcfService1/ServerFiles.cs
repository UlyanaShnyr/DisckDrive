using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService1
{
    [DataContract]
    public class ServerFiles
    {
        [DataMember]
       public byte[] files { get; set; }
        [DataMember]
        public bool IsFile { get; set; }
        [DataMember]
        public string name {get;set;}
        [DataMember]
        public DateTime LastChange { get; set; }
    }
}