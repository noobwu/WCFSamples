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
            using (ServiceHost host = new ServiceHost(typeof(ResourceService)))
            {
                host.Open();
                Console.Read();
            }
        }
    }
}
