using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using Artech.Serialization;

namespace Serialization
{
    class Program
    {
        static void Serialize<T>(T instance, string fileName)
        {
            using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, instance);
            }
            Process.Start(fileName);
        }

        static void Main(string[] args)
        {
            Order order = new Order(3721, Guid.NewGuid())
            {
                Date        = DateTime.Today,
                Customer    = "张三",
                ShipAddress = "江苏省 苏州市 星湖街 328号"
            };
            Serialize<Order>(order, "order.xml");
        }
    }
}
