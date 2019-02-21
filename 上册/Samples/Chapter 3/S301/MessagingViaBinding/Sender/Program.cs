using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Xml.Linq;

namespace Artech.MessagingViaBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri listenUri = new Uri("http://127.0.0.1:3721/listener");
            Binding binding = new BasicHttpBinding();

            //创建、开启信道工厂
            IChannelFactory<IRequestChannel> channelFactory = binding.BuildChannelFactory<IRequestChannel>();
            channelFactory.Open();

            //创建、开启请求信道
            IRequestChannel channel = channelFactory.CreateChannel(new EndpointAddress(listenUri));
            channel.Open();

            //发送请求消息，接收回复消息
            Message replyMessage = channel.Request(CreateRequestMessage(binding));
            Console.WriteLine(replyMessage);

            Console.Read();
        }

        static Message CreateRequestMessage(Binding binding)
        {
            string action = "http://www.artech.com/calculatorservice/Add";
            XNamespace ns = "http://www.artech.com";
            XElement body = new XElement(new XElement(ns + "Add",
                new XElement(ns + "x", 1),
                new XElement(ns + "y", 2)));
            return Message.CreateMessage(binding.MessageVersion, action, body);
        }

    }
}
