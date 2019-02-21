using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.Xml;
using System.Diagnostics;

namespace Artech.MessageContract2Message
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee
            {
                Id = Guid.NewGuid().ToString(),
                Name = "张三",
                Gender = "男",
                Department = "销售部"
            };
            string action = "http://www.artech.com/hr/AddEmployee";
            string ns = "http://www.artech.com/hr";
            GenerateMessage<Employee>(employee, action, ns, "employee.xml");

        }

        public static void GenerateMessage<T>(T typedMessage, string action, string ns, string fileName)
        {
            TypedMessageConverter converter = TypedMessageConverter.Create(typeof(T), action, ns);
            using (Message message = converter.ToMessage(typedMessage))
            {
                using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
                {
                    message.WriteMessage(writer);
                }
            }
            Process.Start(fileName);
        }
    }
}
