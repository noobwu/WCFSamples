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
            MetadataSet metadata = new MetadataSet();
            string address = "http://127.0.0.1:3721/calculatorservice/metadata";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
            request.Method = "Get";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (XmlReader reader = XmlDictionaryReader.CreateTextReader(response.GetResponseStream(), new XmlDictionaryReaderQuotas()))
            {
                System.Web.Services.Description.ServiceDescription serviceDesc = System.Web.Services.Description.ServiceDescription.Read(reader);
                metadata.MetadataSections.Add(MetadataSection.CreateFromServiceDescription(serviceDesc));
            }
            using (XmlWriter writer = new XmlTextWriter("metadata.xml", Encoding.UTF8))
            {
                metadata.WriteTo(writer);
            }
            Process.Start("metadata.xml");

        }
    }
}
