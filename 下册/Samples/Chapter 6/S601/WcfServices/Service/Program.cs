using System;
using System.Messaging;
using System.ServiceModel;
namespace Artech.WcfServices.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @".\private$\XactQueue4Demo";
            if (!MessageQueue.Exists(path))
            {
                MessageQueue.Create(path, true);
            }

            using (ServiceHost host = new ServiceHost(typeof(GreetingService)))
            {
                host.Open();
                Console.Read();
            }
        }
    }
}
