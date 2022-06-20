using CherryServersProject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CherryServerProject.API
{
    internal class Perform
    {
        public string Perf(string Action, string SRVID)
        {
            string AC = "\"" + Action.Trim() + "\"";

            var url = "https://api.cherryservers.com/v1/servers/" + SRVID + "/actions";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Headers["Authorization"] = "Bearer " + Login.tok;
            request.ContentType = "application/json";

            string data = "{\"type\": " + AC + "}";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(data);
                }

                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    string results = result.ToString();
                    return results;
                }
        }
    }
}
