using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.Transactions;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IGreeting proxy;
            using (ChannelFactory<IGreeting> channelFactoryHello = new ChannelFactory<IGreeting>("greetingService"))
            {
                proxy = channelFactoryHello.CreateChannel();
                proxy.SayHello("Foo");

                proxy = channelFactoryHello.CreateChannel();
                proxy.SayGoodbye("Bar");

                proxy = channelFactoryHello.CreateChannel();
                proxy.SayHello("Foo");

                proxy = channelFactoryHello.CreateChannel();
                proxy.SayGoodbye("Bar");
            }
        }
    }
}
