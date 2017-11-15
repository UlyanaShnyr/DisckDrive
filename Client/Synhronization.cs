using Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Synhronization
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        public void Synh(string basePath,string current)
        {
            Task.Run(() =>
            {
                DirectoryInfo di = new DirectoryInfo(current);
                DirectoryInfo[] directories =
                    di.GetDirectories("", SearchOption.AllDirectories);

                var serverDirectories = client.SerchDirectories();

                foreach (var i in directories)
                {
                    if (!serverDirectories.ToList().Contains(i.FullName.Remove(0, basePath.Length)))
                    {
                        i.Delete();
                    }
                }

                foreach (var i in serverDirectories)
                {
                    if (!directories.Select(dir => dir.FullName.Remove(0, basePath.Length)).ToList().Contains(i))
                    {
                        Directory.CreateDirectory(basePath + i);
                    }
                }

            });
        }
    }
}
