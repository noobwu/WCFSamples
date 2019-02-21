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

        static void Main(string[] args)
        {
            Order order = new Order(3721, Guid.NewGuid())
            {
                Date = DateTime.Today,
                Customer = "张三",
                ShipAddress = "江苏省 苏州市 星湖街 328号"
            };

            XmlAttributes attributes = new XmlAttributes();
            attributes.XmlAttribute = new XmlAttributeAttribute("ID");
            XmlAttributeOverrides attributeOverrides = new XmlAttributeOverrides();
            attributeOverrides.Add(typeof(Order), "ID", attributes);
            XmlRootAttribute rootAttribute = new XmlRootAttribute("Ord");

            using (XmlWriter writer = new XmlTextWriter("order.xml", Encoding.UTF8))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Order), attributeOverrides, null, rootAttribute, "http://www.artech.com");
                serializer.Serialize(writer, order);
            }
            Process.Start("order.xml");

        }
    }
}
