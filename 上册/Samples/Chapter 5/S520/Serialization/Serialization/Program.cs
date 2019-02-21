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
        public static void Serialize<T>(T instance, string fileName, IDataContractSurrogate dataContractSurrogate)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T), null, int.MaxValue, false, false, dataContractSurrogate);
            using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                serializer.WriteObject(writer, instance);
                Process.Start(fileName);
            }
        }

        public static T Deserialize<T>(string fileName, IDataContractSurrogate dataContractSurrogate)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T), null, int.MaxValue, false, false, dataContractSurrogate);
            using (XmlReader reader = new XmlTextReader(fileName))
            {
                return (T)serializer.ReadObject(reader);
            }
        }

                      
        static void Main(string[] args)
        {
            string fileName = "contact.xml";
            Contact contact = new Contact
            {
                FullName = "Bill Gates",
                Sex = "Male"
            };
            IDataContractSurrogate dataContractSurrogate = new ContractSurrogate();
            Serialize<Contact>(contact, fileName, dataContractSurrogate);
            Console.WriteLine("序列化前");
            Console.WriteLine("\t{0,-9}: {1}", "FullName", contact.FullName);
            Console.WriteLine("\t{0,-9}: {1}", "Sex", contact.Sex);

            contact = Deserialize<Contact>(fileName, dataContractSurrogate);
            Console.WriteLine("反序列化后");
            Console.WriteLine("\t{0,-9}: {1}", "FullName", contact.FullName);
            Console.WriteLine("\t{0,-9}: {1}", "Sex", contact.Sex);
        }
    }
}
