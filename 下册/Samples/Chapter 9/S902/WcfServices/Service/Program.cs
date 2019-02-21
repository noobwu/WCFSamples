using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service;

namespace Artech.WcfServices.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (CulturePropagationServiceHost host = new CulturePropagationServiceHost(typeof(ResourceService)))
            {
                host.Open();
                Console.Read();
            }
        }
    }
}
