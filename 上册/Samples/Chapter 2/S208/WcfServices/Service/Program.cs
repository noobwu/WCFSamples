using System;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
namespace Artech.WcfServices.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                serviceHost.Open();
                int i = 0;
                foreach (ChannelDispatcher channelDispatcher in serviceHost.ChannelDispatchers)
                {
                    Console.WriteLine("ChannelDispatcher {0}(ListenUri: {1})", ++i, channelDispatcher.Listener.Uri);
                    int j = 0;
                    foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                    {
                        Console.WriteLine("\tEndpointDispatcher {0}(Address: {1})", ++j, endpointDispatcher.EndpointAddress.Uri);
                    }
                }
            }
        }
    }
}
