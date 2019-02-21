using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.ServiceModel.Channels;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Artech.CreateMessage
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
            Order order = new Order
            {
                ID = Guid.NewGuid(),
                Date = DateTime.Today,
                Customer = "张三",
                ShipAddress = "江苏省 苏州市 星湖街 328号"
            };
            string action = "http://www.artech.com/IOrder/sumbit";
            using (Message message = Message.CreateMessage(MessageVersion.Default, action, order))
            {
                WriteMessage(message, "message.xml");
            }
        }
    }
}
