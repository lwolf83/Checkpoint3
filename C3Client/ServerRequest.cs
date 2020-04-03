using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace C3Client
{
    public static class ServerRequest
    {
        public static UserFile GetFile(string path)
        {
            UserFile userFile = Do(path, "GET");
            return userFile;
        }

        public static UserFile CreateFile(string path)
        {
            UserFile userFile = Do(path, "PUT");
            return userFile;
        }

        public static UserFile DeleteFile(string path)
        {
            UserFile userFile = Do(path, "DELETE");
            return userFile;
        }

        private static UserFile Do(string path, string method,string serverUrl = "http://127.0.0.1:1234/")
        {
            string postUrl = serverUrl + "file/" + path;
            var request = (HttpWebRequest)WebRequest.Create(postUrl);
            request.Method = method;
            request.ContentType = "application/xml";
            UserFile returnUser;
            try
            { 
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string returnString = readStream.ReadToEnd();
                returnUser = JsonConvert.DeserializeObject<UserFile>(returnString);
            }
            catch (WebException ex)
            { 
                returnUser = new UserFile
                {
                    Exist = false,
                    Content = "Error code : " + ex.Message,
                    FileSize = 0
                };
            }

            return returnUser;
        }

    }
}
