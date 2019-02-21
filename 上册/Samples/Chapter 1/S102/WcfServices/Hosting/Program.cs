using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using Artech.WcfServices.Service.Interface;
using Artech.WcfServices.Service;
namespace Artech.WcfServices.Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Opened += delegate
                {
                    Console.WriteLine("CalculaorService已经启动，按任意键终止服务！");
                };

                host.Open();
                Console.Read();
            }
        }
    }
}
