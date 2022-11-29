using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public class NetDataParsing
    {
        public static void Convert(double amount, double price, string name)
        {
            Console.WriteLine("{0} PLN are {1} {2} ", amount, amount / price, name);
        }


        public static async void GetLastValue(string userCur)
        {
            string url = "https://api.nbp.pl/api/exchangerates/rates/a/" + userCur + "/?format=json";
            Root myval = new Root();
            myval = await GetData<Root>(url);
            Console.WriteLine("{0} | {1} | {2} | {3}", myval.currency, myval.code, myval.rates[0].effectiveDate, myval.rates[0].mid);
            Convert(100, myval.rates[0].mid, myval.code);
        }
        public static async void TenGetLastValue(string userCur)
        {
            string url = "http://api.nbp.pl/api/exchangerates/rates/a/" + userCur + "/last/10/?format=json";
            Root val = new Root();
            val = await GetData<Root>(url);
            foreach (var rate in val.rates)
            {
                Console.WriteLine("{0} - {1}", rate.mid, rate.effectiveDate);
            }
        }

        public void CheckUserInput(string userString)
        {

        }
        public static async void GetCurrencyNames()
        {
            string url = "https://api.nbp.pl/api/exchangerates/tables/a/today/?format=json";
            CurrencyNames val = new CurrencyNames();
            val = await GetNamesData<CurrencyNames>(url);
            bool result = false;
            string userString = Console.ReadLine();
            while (result==false)
            {
                
                if (userString=="help")
                {
                    PrintNames(val);
                }
                foreach (var rate in val.rates)
                {
                    rate.code = rate.code.ToLower();
                    if (userString == rate.code || userString == rate.currency)
                    {
                        result = true;
                    }
                }
                if (result == false&&userString!="help")
                {
                    Console.WriteLine("Wrong name use dictionary");
                }
                userString= Console.ReadLine();
            }
            GetLastValue(userString);
            TenGetLastValue(userString);
        }
        public static void PrintNames(CurrencyNames val)
        {
            foreach (var rate in val.rates)
            {
                Console.WriteLine("{0} - {1}", rate.currency, rate.code);
            }
        }

        public static async Task<CurrencyNames> GetNamesData<T>(string url)
        {
            var myroot = new CurrencyNames();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var ResponseString = await response.Content.ReadAsStringAsync();
                        ResponseString = ResponseString.Trim('[');
                        ResponseString = ResponseString.Trim(']');
                        var ResponseObject = JsonConvert.DeserializeObject<CurrencyNames>(ResponseString);
                        return ResponseObject;
                    }
                    return myroot;
                }
            }
            catch
            {
                Console.WriteLine("Connection Error");
                return myroot;
            }
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
                Console.WriteLine("Connection Error");
                return myroot;
            }
        }

    }
}
