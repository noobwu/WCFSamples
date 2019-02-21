using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading;
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
                ChannelDispatcher channelDispatcher = (ChannelDispatcher)host.ChannelDispatchers[0];
                EndpointDispatcher endpointDispatcher = channelDispatcher.Endpoints[0];
                ActionMessageFilter messageFilter = (ActionMessageFilter)endpointDispatcher.ContractFilter;
                foreach (string action in messageFilter.Actions)
                {
                    Console.WriteLine(action);
                }
                Console.Read();
            }
        }
    }
}
