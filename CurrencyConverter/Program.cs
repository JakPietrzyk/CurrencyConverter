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

            //GetCurrencyNames();
            //if(userCurInput)
            //GetLastValue(userCurInput);
            //TenGetLastValue(userCurInput);
            //Console.WriteLine("main");
            //Console.ReadKey();
            //Task p = Task.Run(() =>
            //{
            bool flag = true;
            while(flag)
            {
                GetCurrencyNames();
                Console.WriteLine("Enter to try next currency");
                string ui = Console.ReadLine();
                if(ui=="0")
                {
                    break;
                }

            }
            
            System.Threading.Thread.Sleep(20000);
            //});
            //p.Wait();
            //TimeSpan ts = TimeSpan.FromMilliseconds(15000);
            //if (!p.Wait(ts))
            //{ 
            //    Console.WriteLine("The timeout interval elapsed.");
            //}


            Console.ReadKey();
        }


    }
}
