using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.Xml;
using System.Diagnostics;
using System.ServiceModel;

namespace SetMessageHeaders
{
    class Program
    {
        static void WriteMessage(Message message, string fileName)
        {
            using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                message.WriteMessage(writer);
            }
            Process.Start(fileName);
        }

        static void Main(string[] args)
        {
            string action = "http://www.artech.com/crm/AddCustomer";
            using (Message message = Message.CreateMessage(MessageVersion.Soap11WSAddressingAugust2004, action))
            {
                string ns = "http://www.artech.com/crm";
                EndpointAddress address =new EndpointAddress("http://www.artech.com/crm/client");
                message.Headers.To =new Uri("http://www.artech.com/crm/customerservice");
                message.Headers.From = address;
                message.Headers.ReplyTo = address;
                message.Headers.FaultTo = address;
                message.Headers.MessageId = new UniqueId(Guid.NewGuid());
                message.Headers.RelatesTo = new UniqueId(Guid.NewGuid());

                MessageHeader<string> foo = new MessageHeader<string>("ABC");
                MessageHeader<string> bar = new MessageHeader<string>("abc", true,"", false);
                MessageHeader<string> baz = new MessageHeader<string>("123", false,"http://schemas.xmlsoap.org/soap/actor/next", true);

                message.Headers.Add(foo.GetUntypedHeader("Foo", ns));
                message.Headers.Add(bar.GetUntypedHeader("Bar", ns));
                message.Headers.Add(baz.GetUntypedHeader("Baz", ns));

                WriteMessage(message, "message.xml");
            }

        }
    }
}
