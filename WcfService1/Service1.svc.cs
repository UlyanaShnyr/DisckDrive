using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    public class Service1 : IService1
    {
        string basePath = @"D:\root\Server\";

        public Stream Download(string file)
        {
            MemoryStream stream = new MemoryStream();
            var bytes = File.ReadAllBytes(file);
            stream.Write(bytes, 0, bytes.Length);
            stream.Position = 0;
            return stream;
        }

        public string[] ReadAll(string basePath)
        {
            List<string> str =  Directory.GetDirectories(basePath).ToList();
            str.AddRange(Directory.GetFiles(basePath));
            return str.ToArray();
            
        }

        public string Upload(Stream input)
        {
            string fileName = String.Format(@"{0}\{1}.txt", basePath, Guid.NewGuid().ToString());
            StreamReader reader = new StreamReader(input);
            var content = reader.ReadToEnd();
            File.WriteAllText(fileName, content);
            return fileName;
            
        }

        public string CreateFolder (string basePath) { 
          
            DirectoryInfo dirInfo = new DirectoryInfo(this.basePath + basePath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            return basePath;
        }

        public string CreateFile(string basePath)
        {
            File.Create(this.basePath+ basePath);
            return this.basePath + basePath;
        }

        public string Delete(string basePath)
        {
            if (Directory.Exists(this.basePath + basePath))
            {                     
                Directory.Delete(this.basePath + basePath);
            }
            return basePath;
        }

        public string Rename(string old_path, string new_path)
        {
            Directory.Move(basePath+old_path, basePath+new_path);
            return new_path;
        }
    }
    }
