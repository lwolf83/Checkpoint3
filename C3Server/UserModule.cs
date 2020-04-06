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
            Get("/file/{FilePath}", param => ReturnFileData(param.FilePath));           
            Delete("/file/{FilePath}", param => DeleteFile(param.FilePath));
            Put("/file/{FilePath}", param => CreateFile(param.FilePath));

            Get(@"/(.*)", _ =>  HttpStatusCode.Forbidden);
            Put(@"/(.*)", _ => HttpStatusCode.Forbidden);
            Delete(@"/(.*)", _ => HttpStatusCode.Forbidden);

            Get("/", _ => HttpStatusCode.Forbidden);
            Put("/", _ => HttpStatusCode.Forbidden);
            Delete("/", _ => HttpStatusCode.Forbidden);
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
