using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Description;
using System.Net;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            string contentType = "application/json";

            Console.WriteLine("Content-Type = N/A; Accept = N/A:");
            GetAllEmployees("", "");
            Console.WriteLine();

            Console.WriteLine("Content-Type = application/json; Accept = N/A:");
            GetAllEmployees(contentType, "");
            Console.WriteLine();

            Console.WriteLine("Content-Type = N/A, Accept = application/json:");
            GetAllEmployees("", contentType);
            Console.Read();
        }

        static void GetAllEmployees(string contentType, string accept)
        {
            WebClient webClient = new WebClient();
            if (!string.IsNullOrEmpty(contentType))
            {
                webClient.Headers.Add("Content-Type", contentType);
            }

            if (!string.IsNullOrEmpty(accept))
            {
                webClient.Headers.Add("Accept", accept);
            }
            using (StreamReader reader = new StreamReader(webClient.OpenRead("http://127.0.0.1:3721/employees/all")))
            {
                Console.WriteLine(reader.ReadToEnd());
            }

        }
    }
}
