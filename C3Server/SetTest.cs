using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3Server
{
    public static class SetTest
    {
        public static void CreateSet()
        {
            if (!Directory.Exists("www"))
            {
                Directory.CreateDirectory("www");
            }

            for (int i = 0; i < 10; i++)
            {
                string fileName = $"www/File{i}.txt";
                string currentFile = "FileContent " + i + "BlablaBla" + Guid.NewGuid();
                File.WriteAllText(fileName, currentFile);
            }
        }

    }
}
