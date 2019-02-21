using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Web;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;

namespace Artech.WcfServices.Service
{
    public class Program
    {
        static void Main()
        {
            using (WebServiceHost host = new WebServiceHost(typeof(EmployeesService)))
            {
                host.Open();
                Console.Read();
            }
        }
    }
}