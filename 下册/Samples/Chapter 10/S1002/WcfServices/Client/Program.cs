using System;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint());
            FindCriteria criteria = new FindCriteria(typeof(ICalculator));
            criteria.Scopes.Add(new Uri("http://www.artech.com/"));
            FindResponse response = discoveryClient.Find(criteria);

            if (response.Endpoints.Count > 0)
            {
                EndpointAddress address = response.Endpoints[0].Address;
                using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>(new WS2007HttpBinding(), address))
                {
                    ICalculator calculator = channelFactory.CreateChannel();
                    Console.WriteLine("x + y = {2} when x = {0} and y = {1}", 1, 2, calculator.Add(1, 2));
                }
            }
            Console.Read();
        }
    }
}
