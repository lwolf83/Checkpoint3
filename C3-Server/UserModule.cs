using Nancy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3Server
{
    public class UserModule:NancyModule
    {

        public UserModule()
        {
            // Get JSON about a given user
            Get("/file/{FilePath}", param => ReturnFileData(param.FilePath));

            // Delete an existing user            
            Delete("/file/{FilePath}", param => DeleteFile(param.FilePath));

            // Add a new user
            Put("/file/{FilePath}", param => CreateFile(param.FilePath));

        }

        public string ReturnFileData(String path)
        {
            UserFile userFile = new UserFile(path);
            string returnJson = JsonConvert.SerializeObject(userFile);
            return returnJson;
        }

        public string DeleteFile(String path)
        {
            UserFile userFile = new UserFile(path);
            userFile.Delete();
            string res = JsonConvert.SerializeObject(userFile);
            return res;
        }

        public string CreateFile(String path)
        {
            UserFile userFile = new UserFile(path);
            userFile.Create();
            string res = JsonConvert.SerializeObject(userFile);
            return res;
        }

    }
}
