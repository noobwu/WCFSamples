using System;
using System.ServiceModel;
using System.Threading;
using System.ServiceModel.Description;
namespace Artech.WcfServices.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(MessengerService)))
            {
                host.Open();
                Console.Read();
            }
        }
    }
}