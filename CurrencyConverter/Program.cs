using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;


namespace CurrencyConverter
{
    class CurrencyConverter
    {
        static void Main(string[] args)
        {
            Currency myval = new Currency();
            async void GetValue()
            {
                myval = await GetData<Currency>("https://api.nbp.pl/api/exchangerates/rates/a/chf/?format=json");
                //Console.WriteLine("{0} | {1} | {2} | {3}",myval.currency,myval.code,myval.rates.effectiveDate,myval.rates.mid);
                Console.WriteLine("{0} | {1} ", myval.currency, myval.code);
                //Console.WriteLine("{0}",myval.rates);
               // Console.WriteLine(string.Join(", ", myval.rates.ToArray()));
            }
            GetValue();

            Console.ReadKey();
        }

        
        

        public class Rate
        {
            public string effectiveDate { get; set; }
            public double mid { get; set; }
        }

        public class Currency
        {
            public string currency { get; set; }
            public string code { get; set; }
            //public string[] rates { get; set; }
            public Rate[] rates;
        }

        


        public static async Task<Currency> GetData<T>(string url)
        {
                var myroot = new Currency();
           
                //using (var client = new HttpClient())
                //{
                //    client.Timeout = TimeSpan.FromMinutes(1);
                //    HttpResponseMessage response = await client.GetAsync(url);
                //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //    {
                //        var ResponseString = await response.Content.ReadAsStringAsync();
                //        var ResponseObject = JsonConvert.DeserializeObject<Currency>(ResponseString);


                //        return ResponseObject;
                //    }
                //    return myroot;
                //}
                string json = @"{'table':'A','currency':'frank szwajcarski','code':'CHF','rates':[{'no':'228/A/NBP/2022','effectiveDate':'2022-11-25','mid':4.7729}]}";
                var ResponseObject = JsonConvert.DeserializeObject<Currency>(json);
            Console.WriteLine("{0}", ResponseObject.rates[0].mid);
                

            //dynamic dObject = JObject.Parse(json);
            //foreach(var prop in dObject.rates)
            //{
            //    var cur = prop.Value;

            //    Console.WriteLine("{0}",cur.mid);
            //}


            
            



            //Console.WriteLine("{0}|",ResponseObject.code);
            //Console.WriteLine("{0}",ResponseObject.rates);
            Console.ReadKey();
                return ResponseObject;
            
        }

        
    }
}
