using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.ServiceModel;

namespace Artech.WcfServices.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Membership.FindUsersByName("Zhansan").Count == 0)
            {
                Membership.CreateUser("Zhansan", "Pass@word", "zhanshan@gmail.com");
            }
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Open();
                Console.Read();
            }

        }
    }
}
