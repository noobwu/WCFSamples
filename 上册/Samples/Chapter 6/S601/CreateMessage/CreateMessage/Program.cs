using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.ServiceModel.Channels;
using System.Diagnostics;

namespace Artech.CreateMessage
{
    class Program
    {
        static void WriteMessage(Message message, string fileName)
        {
            using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                message.WriteMessage(writer);
            }
            Process.Start(fileName);
        }

        static void Main(string[] args)
        {
            string action = "http://www.artech.com/ICaculator/Add";
            using (Message message = Message.CreateMessage(MessageVersion.Default, action))
            {
                WriteMessage(message, "message.xml");
            }
        }
    }
}
