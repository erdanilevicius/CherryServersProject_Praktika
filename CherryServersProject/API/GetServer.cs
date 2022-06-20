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
using System.Windows;

namespace CherryServersProject.API
{
    internal class GetServer
    {
        public string[] Gserv(string SrvID)
        {

            var url = "https://api.cherryservers.com/v1/servers/" + SrvID;
            var url2 = "https://api.cherryservers.com/v1/servers/" + SrvID + "/ips";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Headers["Authorization"] = "Bearer " + Login.tok;
            List<string> list = new List<string>();


            try
            {
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    string res = result.ToString();

                    Root Deserialized = JsonConvert.DeserializeObject<Root>(res);
                    list.Add("                           Showing information for server:  ' " + Deserialized.hostname.ToString() + " '");
                    list.Add("Resource status: " + Deserialized.state.ToString());
                    list.Add("Resource name: " + Deserialized.name.ToString());
                    list.Add("Resource id:" + Deserialized.id.ToString());
                    list.Add("Region: " + Deserialized.region.name.ToString());
                    list.Add("Image: " + Deserialized.image.ToString());
                    list.Add("Traffic: " + Deserialized.plan.specs.bandwidth.name.ToString());
                    list.Add("Deployment date: " + Deserialized.created_at.ToString());
                    list.Add("Spent this month (21% VAT): " + Math.Round(Convert.ToDouble(Deserialized.pricing.price_total.ToString()), 2).ToString() + " " + Deserialized.pricing.currency.ToString() + " (" + Deserialized.pricing.quantity.ToString() + " " + Deserialized.pricing.unit.ToString().ToLower() + ")");
                    list.Add("Price: " + Deserialized.pricing.unit_price.ToString() + " " + Deserialized.pricing.currency.ToString().ToUpper());
                    list.Add("Billing cycle: " + Deserialized.pricing.unit.ToString());

                    list.Add("");
                    list.Add("CPU: " + Deserialized.plan.specs.cpus.cores.ToString() + " @ " + Deserialized.plan.specs.cpus.frequency.ToString() + " " + Deserialized.plan.specs.cpus.unit.ToString());
                    list.Add("RAM: " + Deserialized.plan.specs.memory.name.ToString());
                    list.Add("NIC: " + Deserialized.plan.specs.nics.name.ToString());
                    list.Add("");

                }
                var httpRequest2 = (HttpWebRequest)WebRequest.Create(url2);

                httpRequest2.Headers["Authorization"] = "Bearer " + Login.tok;
                var httpResponse2 = (HttpWebResponse)httpRequest2.GetResponse();
                using (var streamReader = new StreamReader(httpResponse2.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    string res = result.ToString();


                    JObject answ = JObject.Parse("{\"IPS\":" + res + "}");

                    foreach (var ans in answ["IPS"])
                    {
                        Ips Deserialized = JsonConvert.DeserializeObject<Ips>(ans.ToString());
                        list.Add(Deserialized.type.ToString() + ": " + Deserialized.address.ToString());
                    }

                }
                string[] Answer = list.ToArray();
                return Answer;

            }
            catch {

                string head = "Error";
                string bod = "Please enter correct server ID";
                MsgBox msg = new MsgBox(head,bod);
                msg.Show();
                return null;
            }
           
        }

    }
    
    // Getting and setting info got from json file
    public class Root
    {
        public int id { get; set; }
        public string name { get; set; }
        public string href { get; set; }
        public string hostname { get; set; }
        public string image { get; set; }
        public bool spot_instance { get; set; }
        public Region region { get; set; }
        public string state { get; set; }
        public Plan plan { get; set; }
        public Pricing pricing { get; set; }
        public int vlan { get; set; }
        public string termination_date { get; set; }
        public bool upgradable { get; set; }
        public DateTime created_at { get; set; }
    }

    public class AvailableRegion
    {
        public int id { get; set; }
        public string name { get; set; }
        public string region_iso_2 { get; set; }
        public int stock_qty { get; set; }
        public int spot_qty { get; set; }
        public string href { get; set; }
        public string location { get; set; }
    }

    public class Bandwidth
    {
        public string name { get; set; }
    }

    public class Cpus
    {
        public int count { get; set; }
        public string name { get; set; }
        public int cores { get; set; }
        public double frequency { get; set; }
        public string unit { get; set; }
    }
    public class Memory
    {
        public int count { get; set; }
        public int total { get; set; }
        public string unit { get; set; }
        public string name { get; set; }
    }

    public class Nics
    {
        public string name { get; set; }
    }

    public class Plan
    {
        public Specs specs { get; set; }
    }

    public class Pricing
    {
        public int id { get; set; }
        public string currency { get; set; }
        public string unit { get; set; }
        public double unit_price { get; set; }
        public double discount { get; set; }
        public bool discount_percentage { get; set; }
        public double price_subtotal { get; set; }
        public bool taxed { get; set; }
        public double price_total { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public double billable_amount { get; set; }
    }


    public class Region
    {
        public int id { get; set; }
        public string name { get; set; }
        public string region_iso_2 { get; set; }
        public string href { get; set; }
        public string location { get; set; }
    }

    public class Specs
    {
        public Cpus cpus { get; set; }
        public Memory memory { get; set; }
        public List<Storage> storage { get; set; }
        public Nics nics { get; set; }
        public Bandwidth bandwidth { get; set; }
    }

    public class Storage
    {
        public int count { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public string unit { get; set; }
        public string type { get; set; }
    }
    ///////////////////////////////////////
    ///  End of base server info        ///
    ///////////////////////////////////////  


    //Ip Addresses


    public class Ips
    {
        public string id { get; set; }
        public string address { get; set; }
        public int address_family { get; set; }
        public string type { get; set; }
    }

}
