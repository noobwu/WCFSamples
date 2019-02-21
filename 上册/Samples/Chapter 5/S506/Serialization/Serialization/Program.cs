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
        public static void Serialize<T>(T instance, string fileName, int maxItemsInObjectGraph)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T), null, maxItemsInObjectGraph, false, false, null);
            using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                serializer.WriteObject(writer, instance);
            }
            Process.Start(fileName);
        }



        static void Main(string[] args)
        {
            OrderCollection orders = new OrderCollection();
            for (int i = 0; i < 10; i++)
            {
                Order order = new Order()
                {
                    ID = Guid.NewGuid(),
                    Date = DateTime.Today,
                    Customer = "张三",
                    ShipAddress = "江苏省 苏州市 星湖街 328号",
                };
                orders.Add(order);
            }
            Serialize(orders, "order.xml", 10 * 5);
        }
    }
}
