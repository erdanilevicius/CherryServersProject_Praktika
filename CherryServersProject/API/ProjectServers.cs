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

namespace CherryServersProject.API
{
    internal class ProjectServers
    {

        public static string srvID;
        public static string srvName;
        public static string srvConfig;
        public static string OS;
        public static string Hourly;
        public static string Cost;
        public static string Status;
        public string[] PServers(string ProjectID)
        {

            var url = "https://api.cherryservers.com/v1/projects/" + ProjectID + "/servers";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Headers["Authorization"] = "Bearer " + Login.tok;


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                string res = result.ToString();

                JObject answ = JObject.Parse("{\"SRV\":" + res + "}");
                List<string> list = new List<string>();
                foreach (var ans in answ["SRV"])
                {
                    
                    Srv Deserialized = JsonConvert.DeserializeObject<Srv>(ans.ToString());
                    list.Add(Deserialized.id.ToString());
                    list.Add(Deserialized.hostname.ToString());
                    list.Add(Deserialized.name.ToString());
                    list.Add(Deserialized.image.ToString());
                    list.Add(Deserialized.pricing.unit.ToString());
                    list.Add(Deserialized.pricing.unit_price.ToString() + " " + Deserialized.pricing.currency.ToString());
                    list.Add(Deserialized.state.ToString()) ;
                }
                string[] Answer = list.ToArray();
                return Answer;

            }
        }

    }
    public class Srv
    {
        public  int id { get; set; }
        public string name { get; set; }
        public string hostname { get; set; }
        public string image { get; set; }
        public Price pricing { get; set; }
        public string state { get; set; }
    }

    public class Price
    {
        public string currency { get; set; }
        public string unit { get; set; }
        public double unit_price { get; set; }

    }

}
