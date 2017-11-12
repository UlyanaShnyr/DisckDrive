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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string Upload(Stream input);
        [OperationContract]
        Stream Download(String file);

        [OperationContract]
        string[] ReadAll(string path);

        [OperationContract]
        string CreateFolder (string path);

        [OperationContract]
        string CreateFile(string path);

        [OperationContract]
        string Delete(string path);

        [OperationContract]
        string Rename(string old_path, string new_path);

        [OperationContract]
        List<string> SearchFiles(string path);

        [OperationContract]
        List<string> SerchDirectories();
    }
}
