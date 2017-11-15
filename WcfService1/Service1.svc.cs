using System;
using System.Collections.Generic;
using System.Configuration;
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
        static string con = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        MyDrive db = new MyDrive(con);
       
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
            List<string> str = Directory.GetDirectories(basePath).ToList();
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

        public string CreateFolder(string basePath)
        {

            string path = this.basePath + basePath;
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            return basePath;
        }

        public string CreateFile(string basePath)
        {
            string path = this.basePath + basePath;
            FileInfo f = new FileInfo(path);
            if (!f.Exists)
            {
                f.Create();
            }
            return basePath;
        }

        public string Delete(string basePath)
        {
            if (Directory.Exists(this.basePath + basePath))
            {
                Directory.Delete(this.basePath + basePath,true);
            }
            else
            {
                File.Delete(this.basePath + basePath);
            }

            return basePath;
        }

        public string Rename(string old_path, string new_path)
        {
            if (Directory.Exists(basePath + old_path))
            {
                Directory.Move(basePath + old_path, basePath + new_path);
                return new_path;
            }
            else
            {
                File.Move(basePath + old_path, basePath + new_path);
                return new_path;
            }
        }

        public void AllPath(string path, List<string> all)
        {
            if (Directory.GetDirectories(path).Length > 0)
                all.AddRange(Directory.GetDirectories(path));

     
            
            for (int i = 0; i < Directory.GetDirectories(path).Length; i++)
            {
                AllPath(Directory.GetDirectories(path)[i], all);
            }

        }

        public List<string> SerchDirectories()
        {
            List<string> allDirectories = new List<string>();
            AllPath(basePath, allDirectories);

            for (int i = 0; i < allDirectories.Count; i++)
            {
                allDirectories[i] = allDirectories[i].Remove(0, basePath.Length);
            }

            return allDirectories;
        }

        public void AllFilesPath(string path, List<ServerFiles> allList)
        {
            if(Directory.GetFiles(basePath+path).Length>0)
            //allList.AddRange(Directory.GetFiles(basePath  + path));
            for(int i = 0; i < Directory.GetFiles(basePath + path).Length;i++)
                {
                    allList.Add(new ServerFiles()
                    {
                        name = Directory.GetFiles(basePath + path)[i],
                        files = File.ReadAllBytes(Directory.GetFiles(basePath + path)[i]),
                        IsFile = true,
                        LastChange = File.GetLastWriteTime(Directory.GetFiles(basePath + path)[i])
                    });
                }
            for(int i = 0;i < Directory.GetDirectories(basePath + path).Length;i++)
            {
                AllFilesPath(Directory.GetDirectories(basePath  + path)[i], allList);
            }
        }
        public List<ServerFiles> SearchFiles(string path)
        {
            List<ServerFiles> files = new List<ServerFiles>();

            AllFilesPath(path, files);

            for(int i = 0; i< files.Count; i++)
            {
                files[i].name = files[i].name.Remove(0, basePath.Length);
            }
            return files;
        }

        public string Regist(User user)
        {
            if (db.Users.Where(usr => usr.Login == user.Login).Count() > 0)
                return "User with the same login alllready exsist";
            
            db.Users.Add(user);
            db.SaveChanges();
            Directory.CreateDirectory(basePath + user.Login);
            return user.Login;
            
            
        }

        public User Log(string login, string password)
        {
            var tmp = db.Users.Where(user => user.Login == login && user.Password == password).ToList();
            if (tmp.Count > 0)
            {
                return tmp[0];
            } 
            return null;

  
        }
    }


   
}
