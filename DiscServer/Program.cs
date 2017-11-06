using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using WcfService1;

namespace DiscServer{
   
      
        class Program {
            static void Main(string[] args)
            {
                ServiceHost host = new ServiceHost(typeof(Service1));
                host.Open();
                Console.WriteLine("Service is ready");
                Console.ReadLine();
            }
            }
    
}
