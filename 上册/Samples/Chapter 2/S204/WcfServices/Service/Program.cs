using System;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
namespace Artech.WcfServices.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Open();
                int i = 0;
                foreach (ChannelDispatcher channelDispatcher in host.ChannelDispatchers)
                {
                    Console.WriteLine("{0}: {1}", ++i, channelDispatcher.Listener.Uri);
                }
            }
        }
    }
}
