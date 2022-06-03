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

namespace CherryServersProject
{
    internal class Login
    {

        public static string tok;

        public string Logon(string Email, string hash)
        {
            string em = "\"" + Email + "\"";
            string pss = "\"" + hash + "\"";

            var request = (HttpWebRequest)WebRequest.Create("https://mesa.cherryservers.com/api/v1/client-sessions");
            request.Method = "POST";
            request.ContentType = "application/json";

            var data = "{\"username\": " + em + ", \"password\": " + pss + " }";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
            }

            var response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                string rezultatas = result.ToString();


                JObject gaut = JObject.Parse("{\"USR\":" + result + "}");
                List<string> strings = new List<string>();

                Usr obj = System.Text.Json.JsonSerializer.Deserialize<Usr>(rezultatas);
                tok = obj.api_token;

                return tok;

            }
        }

    }

    public class Usr
    {
        public string hash { get; set; }
        public string api_token { get; set; }
        //public int verification_type { get; set; }
        //public bool is_primary { get; set; }
        //public bool email_confirmed { get; set; }
        //public string username { get; set; }
        //public int admin_id { get; set; }
        //public int client_id { get; set; }
        //public int contact_id { get; set; }
        //public string email { get; set; }
        //public string ip_address { get; set; }
        //public int default_team { get; set; }
        //public int default_project { get; set; }
        //public bool facebook { get; set; }
        //public bool google { get; set; }
        //public bool allow_promo { get; set; }
        //public int identity_status { get; set; }
    }

}
