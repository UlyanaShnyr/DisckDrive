﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfService1.Proxy {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Proxy.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Upload", ReplyAction="http://tempuri.org/IService1/UploadResponse")]
        string Upload(System.IO.Stream input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Upload", ReplyAction="http://tempuri.org/IService1/UploadResponse")]
        System.Threading.Tasks.Task<string> UploadAsync(System.IO.Stream input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Download", ReplyAction="http://tempuri.org/IService1/DownloadResponse")]
        System.IO.Stream Download(string file);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Download", ReplyAction="http://tempuri.org/IService1/DownloadResponse")]
        System.Threading.Tasks.Task<System.IO.Stream> DownloadAsync(string file);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadAll", ReplyAction="http://tempuri.org/IService1/ReadAllResponse")]
        string[] ReadAll(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ReadAll", ReplyAction="http://tempuri.org/IService1/ReadAllResponse")]
        System.Threading.Tasks.Task<string[]> ReadAllAsync(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateFolder", ReplyAction="http://tempuri.org/IService1/CreateFolderResponse")]
        string CreateFolder(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateFolder", ReplyAction="http://tempuri.org/IService1/CreateFolderResponse")]
        System.Threading.Tasks.Task<string> CreateFolderAsync(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateFile", ReplyAction="http://tempuri.org/IService1/CreateFileResponse")]
        string CreateFile(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateFile", ReplyAction="http://tempuri.org/IService1/CreateFileResponse")]
        System.Threading.Tasks.Task<string> CreateFileAsync(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Delete", ReplyAction="http://tempuri.org/IService1/DeleteResponse")]
        string Delete(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Delete", ReplyAction="http://tempuri.org/IService1/DeleteResponse")]
        System.Threading.Tasks.Task<string> DeleteAsync(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Rename", ReplyAction="http://tempuri.org/IService1/RenameResponse")]
        string Rename(string old_path, string new_path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Rename", ReplyAction="http://tempuri.org/IService1/RenameResponse")]
        System.Threading.Tasks.Task<string> RenameAsync(string old_path, string new_path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SearchFiles", ReplyAction="http://tempuri.org/IService1/SearchFilesResponse")]
        string[] SearchFiles(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SearchFiles", ReplyAction="http://tempuri.org/IService1/SearchFilesResponse")]
        System.Threading.Tasks.Task<string[]> SearchFilesAsync(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SerchDirectories", ReplyAction="http://tempuri.org/IService1/SerchDirectoriesResponse")]
        string[] SerchDirectories();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SerchDirectories", ReplyAction="http://tempuri.org/IService1/SerchDirectoriesResponse")]
        System.Threading.Tasks.Task<string[]> SerchDirectoriesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WcfService1.Proxy.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WcfService1.Proxy.IService1>, WcfService1.Proxy.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Upload(System.IO.Stream input) {
            return base.Channel.Upload(input);
        }
        
        public System.Threading.Tasks.Task<string> UploadAsync(System.IO.Stream input) {
            return base.Channel.UploadAsync(input);
        }
        
        public System.IO.Stream Download(string file) {
            return base.Channel.Download(file);
        }
        
        public System.Threading.Tasks.Task<System.IO.Stream> DownloadAsync(string file) {
            return base.Channel.DownloadAsync(file);
        }
        
        public string[] ReadAll(string path) {
            return base.Channel.ReadAll(path);
        }
        
        public System.Threading.Tasks.Task<string[]> ReadAllAsync(string path) {
            return base.Channel.ReadAllAsync(path);
        }
        
        public string CreateFolder(string path) {
            return base.Channel.CreateFolder(path);
        }
        
        public System.Threading.Tasks.Task<string> CreateFolderAsync(string path) {
            return base.Channel.CreateFolderAsync(path);
        }
        
        public string CreateFile(string path) {
            return base.Channel.CreateFile(path);
        }
        
        public System.Threading.Tasks.Task<string> CreateFileAsync(string path) {
            return base.Channel.CreateFileAsync(path);
        }
        
        public string Delete(string path) {
            return base.Channel.Delete(path);
        }
        
        public System.Threading.Tasks.Task<string> DeleteAsync(string path) {
            return base.Channel.DeleteAsync(path);
        }
        
        public string Rename(string old_path, string new_path) {
            return base.Channel.Rename(old_path, new_path);
        }
        
        public System.Threading.Tasks.Task<string> RenameAsync(string old_path, string new_path) {
            return base.Channel.RenameAsync(old_path, new_path);
        }
        
        public string[] SearchFiles(string path) {
            return base.Channel.SearchFiles(path);
        }
        
        public System.Threading.Tasks.Task<string[]> SearchFilesAsync(string path) {
            return base.Channel.SearchFilesAsync(path);
        }
        
        public string[] SerchDirectories() {
            return base.Channel.SerchDirectories();
        }
        
        public System.Threading.Tasks.Task<string[]> SerchDirectoriesAsync() {
            return base.Channel.SerchDirectoriesAsync();
        }
    }
}
