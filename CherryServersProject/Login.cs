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

            // Hash is just password right now because of login changes

            string em = "\"" + Email + "\"";
            string pss = "\"" + hash + "\"";

            var request = (HttpWebRequest)WebRequest.Create("https://mesa.cherryservers.com/api/v1/client-sessions");
            request.Method = "POST";
            request.ContentType = "application/json";

            var data = "{\"username\": " + em + ", \"password\": " + pss + " }";

            try
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(data);
                }

                var response = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    string rezultatas = result.ToString();

                    List<string> strings = new List<string>();

                    Usr obj = System.Text.Json.JsonSerializer.Deserialize<Usr>(rezultatas);
                    tok = obj.api_token;

                    return tok;

                }

            }
            catch {
                string Head = "Error";
                string Msg = "Incorrect Credentials";
                MsgBox mm = new MsgBox(Head,Msg);
                mm.Show();

                string a= "fail";
                return a;
            }   
        }
    }

    public class Usr
    {
        public string api_token { get; set; }
    }

}
