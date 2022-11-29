using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows;
using static System.Net.WebRequestMethods;


namespace CurrencyConverter
{
    class CurrencyConverter: NetDataParsing
    {
        static void Main(string[] args)
        {
            GetCurrencyNames();
            
            //if(userCurInput)
            //GetLastValue(userCurInput);
            //TenGetLastValue(userCurInput);

            Console.ReadKey();
        }
    }
}
