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
        static void Serialize<T>(T instance, string fileName, bool preserveReference)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T),null, int.MaxValue, false, preserveReference, null);
            using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                serializer.WriteObject(writer, instance);
            }
            Process.Start(fileName);
        }

        static void Main(string[] args)
        {
            Address address = new Address
            {
                Province = "江苏",
                City = "苏州",
                District = "工业园区",
                Road = "星湖街 328号"
            };

            Customer customer = new Customer()
            {
                Name = "张三",
                Phone = "8888-88888888",
                ShipAddress = address,
                CompanyAddress = address
            };

            Serialize<Customer>(customer, "customer1.xml", false);
            Serialize<Customer>(customer, "customer2.xml", true);

        }
    }
}
