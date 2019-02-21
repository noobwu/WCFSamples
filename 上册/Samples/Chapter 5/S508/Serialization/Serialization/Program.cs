using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using Artech.Serialization;
using System.Runtime.Serialization;

namespace Serialization
{
    class Program
    {
        static void Serialize<T>(T instance, string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                serializer.WriteObject(writer, instance);
            }
            Process.Start(fileName);
        }

        static void Main(string[] args)
        {
            Order order = new Order()
            {
                ID = Guid.NewGuid(),
                Customer = "张三",
                Date = DateTime.Today,
                ShipAddress = "江苏省 苏州市 星湖街 328号",
                TotalPrice = 8888.88
            };

            Serialize<IOrder>(order, "order.xml");
        }
    }
}
