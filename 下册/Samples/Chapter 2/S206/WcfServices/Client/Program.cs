using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.Net;
using System.Xml;
using System.Diagnostics;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://127.0.0.1:9999/calculatorservice/metadata");
            MetadataExchangeClient metadataExchangeClient = new MetadataExchangeClient(address, MetadataExchangeClientMode.HttpGet);
            metadataExchangeClient.ResolveMetadataReferences = false;
            MetadataSet metadata = metadataExchangeClient.GetMetadata();
            using (XmlWriter writer = new XmlTextWriter("metadata.xml", Encoding.UTF8))
            {
                metadata.WriteTo(writer);
            }
            Process.Start("metadata.xml");
        }
    }
}
