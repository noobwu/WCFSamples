using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.ServiceModel.Channels;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;

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
            FaultCode code = FaultCode.CreateSenderFaultCode("calcuError", "http://www.artech.com");
            FaultReasonText reasonText1 = new FaultReasonText("Divided by zero!", "en-US");
            FaultReasonText reasonText2 = new FaultReasonText("试图除以零!", "zh-CN");
            FaultReason reason = new FaultReason(new FaultReasonText[] { reasonText1, reasonText2 });
            MessageFault fault = MessageFault.CreateFault(code, reason);
            string action = "http://www.artech.com/divideFault";
            using (Message message = Message.CreateMessage(MessageVersion.Default, fault, action))
            {
                WriteMessage(message, "message.xml");
            }
        }
    }
}
