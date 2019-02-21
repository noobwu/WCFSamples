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

        public static T Deserialize<T>(string fileName)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            using (XmlReader reader = new XmlTextReader(fileName))
            {
                return (T)serializer.ReadObject(reader);
            }
        }


        
        static void Main(string[] args)
        {
            string fileName = "customer.xml";
            CustomerV1 customerV1 = new CustomerV1
            {
                Name = "张三",
                PhoneNo = "9999-99999999"
            };
            Console.WriteLine("CustomerV1");
            Console.WriteLine("\tName\t: {0}\n\tPhoneNo\t: {1}",
                customerV1.Name, customerV1.PhoneNo);

            Serialize<CustomerV1>(customerV1, fileName);
            CustomerV2 customerV2 = Deserialize<CustomerV2>(fileName);
            Console.WriteLine("CustomerV2");
            Console.WriteLine("\tName\t: {0}\n\tPhoneNo\t: {1}\n\tAddress\t: {2}", customerV2.Name, customerV2.PhoneNo, customerV2.Address ?? "NIL");
        }
    }
}
