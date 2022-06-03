using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;


namespace WpfApp1.API
{
    internal class Projects
    {
        public string[] Project(string TeamID)
        {

            var url = "https://api.cherryservers.com/v1/teams/"+TeamID+"/projects";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Headers["Authorization"] = "Bearer " + Login.tok;


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                string res = result.ToString();

                JObject answ = JObject.Parse("{\"PROJE\":" + res + "}");
                List<string> list = new List<string>();
                foreach (var ans in answ["PROJE"])
                {
                    Proje Deserialized = JsonConvert.DeserializeObject<Proje>(ans.ToString());
                    list.Add(Deserialized.id.ToString());
                    list.Add(Deserialized.name.ToString());

                }
                string[] Answer = list.ToArray();
                return Answer;

            }



        }

    }

    public class Proje
    {
        public int id { get; set; }
        public string name { get; set; }

    }

}
