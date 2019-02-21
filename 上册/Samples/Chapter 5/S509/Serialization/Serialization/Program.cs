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
        public static void Serialize<T>(T instance, string fileName, params Type[] knownTypes)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T),knownTypes, int.MaxValue, false, false, null);
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
                Date = DateTime.Today,
                Customer = "张三",
                ShipAddress = "江苏省 苏州市 星湖街 328号",
                TotalPrice = 8888.88
            };
            Serialize<IOrder>(order, "order.interface.xml", typeof(Order));
            Serialize<OrderBase>(order, "order.class.xml", typeof(Order));
        }
    }
}
