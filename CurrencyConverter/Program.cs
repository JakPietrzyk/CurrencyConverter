using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace CurrencyConverter
{
    class CurrencyConverter
    {
        static void Main(string[] args)
        {
            Root val = new Root();
            async void GetValue()
            {
                val = await GetData<Root>("https://openexchangerates.org/api/latest.json?app_id=51ef38854bd44ec6b04b1800b06792bd&base=PLN");
                Console.WriteLine("{0}",val.rates.EUR);
            }
            GetValue();

            Console.ReadKey();
        }

        
        public class Root
        {
            public Rate rates { get; set; }
            public long timestamp;
            public string license;
        }

        public class Rate
        {
            public double USD { get; set; }
            public double PLN { get; set; }
            public double EUR { get; set; }
        }

        


        public static async Task<Root> GetData<T>(string url)
        {
            var myroot = new Root();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var ResponseString = await response.Content.ReadAsStringAsync();
                        var ResponseObject = JsonConvert.DeserializeObject<Root>(ResponseString);

                        return ResponseObject;
                    }
                    return myroot;
                }
            }
            catch
            {
                Console.WriteLine("Error no connection");
                return myroot;
            }
        }

        
    }
}
