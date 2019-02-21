using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace Artech.XmlEncoding
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee
            {
                Id = "001",
                Name = "张三",
                Gender = "男",
                Department = "销售部"
            };
            string startInfo = "Application/soap+xml";
            string boundary = "http://www.artech.com/boundary";
            string startUri = "http://www.artech.com/contentid";
            WriteObject<Employee>(employee, stream => XmlDictionaryWriter.CreateMtomWriter(stream, Encoding.UTF8, int.MaxValue, startInfo, boundary, startUri, true, false));
        }

        static void WriteObject<T>(T graph, Func<Stream, XmlDictionaryWriter> createWriter)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (XmlDictionaryWriter writer = createWriter(stream))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                    serializer.WriteObject(writer, graph);
                }

                long count = stream.Position;
                byte[] bytes = stream.ToArray();
                StreamReader reader = new StreamReader(stream);
                stream.Position = 0;
                string content = reader.ReadToEnd();

                Console.WriteLine("字节数为：{0}\n", count);
                Console.WriteLine("编码后的二进制表示为：{0}\n", BitConverter.ToString(bytes));
                Console.WriteLine("编码后的文本表示为：{0}", content);
            }
        }
    }
}
