using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace C3Client
{
    public class UserFile
    {
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public string Content { get; set; }
        public bool Exist { get; set; }
        public long FileSize { get; set; }

    }
}
