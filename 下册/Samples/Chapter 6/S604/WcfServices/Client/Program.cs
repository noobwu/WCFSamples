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
            using (ChannelFactory<IGreeting> channelFactoryHello = new ChannelFactory<IGreeting>("greetingService"))
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    IGreeting proxy = channelFactoryHello.CreateChannel();
                    proxy.SayHello("Foo");
                    proxy.SayGoodbye("Bar");
                    (proxy as ICommunicationObject).Close();
                    scope.Complete();
                }
            }
        }
    }
}
