using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;

namespace XmlDictionaryUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<XmlDictionaryString> dictionaryStringList = new List<XmlDictionaryString>();
            XmlDictionary dictionary = new XmlDictionary();
            dictionaryStringList.Add(dictionary.Add("Employee"));
            dictionaryStringList.Add(dictionary.Add("Id"));
            dictionaryStringList.Add(dictionary.Add("Name"));
            dictionaryStringList.Add(dictionary.Add("Gender"));
            dictionaryStringList.Add(dictionary.Add("Department"));
            Console.WriteLine("{0,-4}{1}", "Key", "Value");
            Console.WriteLine(new string('-', 20));
            foreach (XmlDictionaryString dictionaryString in dictionaryStringList)
            {
                Console.WriteLine("{0,-4}{1}", dictionaryString.Key, dictionaryString.Value);
            }
        }
    }
}
