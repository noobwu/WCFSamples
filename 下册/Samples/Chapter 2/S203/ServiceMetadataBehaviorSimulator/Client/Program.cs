using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;
using Artech.ServiceMetadataBehaviorSimulator;
using System.ServiceModel.Description;
using System.Xml;
using System.Diagnostics;

namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<IMetadataProvisionService> channelFactory = new ChannelFactory<IMetadataProvisionService>("mex"))
            {
                IMetadataProvisionService proxy = channelFactory.CreateChannel();
                string action = "http://schemas.xmlsoap.org/ws/2004/09/transfer/Get";
                Message request = Message.CreateMessage(MessageVersion.Default, action);
                Message reply = proxy.Get(request);
                MetadataSet metadata = reply.GetBody<MetadataSet>();
                using (XmlWriter writer = new XmlTextWriter("metadata.xml", Encoding.UTF8))
                {
                    metadata.WriteTo(writer);
                }
                Process.Start("metadata.xml");
            }
        }
    }
}
