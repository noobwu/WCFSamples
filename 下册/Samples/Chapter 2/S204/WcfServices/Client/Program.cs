using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;
namespace Artech.MetataRetrieval
{
    class Program
    {
        static void Main(string[] args)
        {
            MetadataSet metadata = null;
            using (ChannelFactory<IMetadataExchange> channelFactory = new ChannelFactory<IMetadataExchange>(MetadataExchangeBindings.CreateMexHttpBinding(), new EndpointAddress("http://127.0.0.1:9999/calculatorservice/mex")))
            {
                IMetadataExchange proxy = channelFactory.CreateChannel();
                using (proxy as IDisposable)
                {
                    string action = "http://schemas.xmlsoap.org/ws/2004/09/transfer/Get";
                    Message request = Message.CreateMessage(MessageVersion.Default, action);
                    metadata = proxy.Get(request).GetBody<MetadataSet>();
                }
            }
            using (XmlWriter writer = new XmlTextWriter("metadata.xml", Encoding.UTF8))
            {
                metadata.WriteTo(writer);
            }
            Process.Start("metadata.xml");
        }
    }
}
