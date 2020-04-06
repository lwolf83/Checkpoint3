using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3Server
{
    class UserFile
    {

        private string _root = "www/";
        public string FilePath { get; set; }
        
        public string FileExtension => Path.GetExtension(_root + FilePath);
        public string Content => ReturnContent();
        public bool Exist => File.Exists(_root + FilePath);
        public long FileSize => Exist ? new FileInfo(_root + FilePath).Length : 0;

        public UserFile(string path)
        {
            string fullpath = _root + path;
            FilePath = path;
        }

        private string ReturnContent()
        {
            string resContent = "";
            if(Exist)
            {
                resContent = File.ReadAllText(_root + FilePath);
            }
            return resContent;
        }


        public void Delete()
        {
            File.Delete(_root + FilePath);
        }

        public void Create()
        {
            if (!Exist)
            {
                File.WriteAllText(_root + FilePath, "");
            }
        }
    }
}
