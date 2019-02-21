using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using Artech.Serialization;
using System.Runtime.Serialization;
using System.Collections;

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
            Customer customer1 = new Customer
            {
                ID = Guid.NewGuid(),
                Name = "张三",
                Phone = "8888-88888888",
                CompanyAddress = "江苏省 苏州市 星湖街 328号"
            };
            Customer customer2 = new Customer
            {
                ID = Guid.NewGuid(),
                Name = "李四",
                Phone = "9999-99999999",
                CompanyAddress = "江苏省 苏州市 金鸡湖大道 328号"
            };
            Serialize<CustomerCollection>(new CustomerCollection(customer1, customer2), "customers.xml");

        }
    }
}
