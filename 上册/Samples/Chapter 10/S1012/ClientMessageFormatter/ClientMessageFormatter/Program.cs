using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using Artech.WebHttpModel;

namespace ClientMessageFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress address = new EndpointAddress("http://127.0.0.1:3721/demoservice");
            Binding binding = new WebHttpBinding();
            ContractDescription contract = ContractDescription.GetContract(typeof(IContract));
            ServiceEndpoint endpoint = new ServiceEndpoint(contract, binding, address);
            using (ChannelFactory<IContract> channelFactory = new ChannelFactory<IContract>(endpoint))
            {
                channelFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());
                channelFactory.Open();
            }
        }
    }
}
 
