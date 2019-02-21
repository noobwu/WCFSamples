using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.Runtime.Remoting;
using System.Diagnostics;

namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
            {
                ICalculator calculator = channelFactory.CreateChannel();
                (calculator as ICommunicationObject).Open();
                IContextChannel contextChannel = (IContextChannel)calculator;

                Console.WriteLine("{0, -21}: {1}", "LocalAddress", contextChannel.LocalAddress);
                Console.WriteLine("{0, -21}: {1}", "RemoteAddress", contextChannel.RemoteAddress);

                Console.WriteLine("{0, -21}: {1}", "InputSession == Null", contextChannel.InputSession == null);
                Console.WriteLine("{0, -21}: {1}", "OutputSession== Null", contextChannel.OutputSession == null);
                Console.WriteLine("{0, -21}: {1}", "SessionId", contextChannel.SessionId);

                Console.WriteLine("{0, -21}: {1}", "OperationTimeout", contextChannel.AllowOutputBatching);
                Console.WriteLine("{0, -21}: {1}", "OperationTimeout", contextChannel.OperationTimeout);
            }
            Console.Read();
        }
    }
}