using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.Net;
using System.Xml;
using System.Diagnostics;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Channels;

namespace Client
{
    class Program
    {

        static void Main(string[] args)
        {
            Binding binding = MetadataExchangeBindings.CreateMexHttpBinding();
            EndpointAddress address = new EndpointAddress("http://127.0.0.1:9999/calculatorservice/mex");
            MetadataExchangeClient metadataExchangeClient = new MetadataExchangeClient(binding);
            MetadataSet metadata = metadataExchangeClient.GetMetadata(address);
            WsdlImporter wsdlImporter = new WsdlImporter(metadata);
            //添加已知契约类型
            ContractDescription contract = ContractDescription.GetContract(typeof(ICalculator));
            wsdlImporter.KnownContracts.Add(new XmlQualifiedName(contract.Name, contract.Namespace), contract);
            ServiceEndpointCollection endpoints = wsdlImporter.ImportAllEndpoints();
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>(endpoints[0]))
            {
                ICalculator calculator = channelFactory.CreateChannel();
                Console.WriteLine("x + y = {2} when x = {0} and y = {1}", 1, 2, calculator.Add(1, 2));
            }
            Console.Read();
        }
    }
}