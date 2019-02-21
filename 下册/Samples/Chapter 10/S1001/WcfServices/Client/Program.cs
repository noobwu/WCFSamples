using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<IHello> channelFactoryHello = new ChannelFactory<IHello>("helloService"))
            using (ChannelFactory<IGoodbye> channelFactoryGoodbye = new ChannelFactory<IGoodbye>("goodbyeService"))
            {
                IHello helloProxy = channelFactoryHello.CreateChannel();
                IGoodbye goodbyeProxy = channelFactoryGoodbye.CreateChannel();
                Console.WriteLine(helloProxy.SayHello("Zhang San"));
                Console.WriteLine(goodbyeProxy.SayGoodbye("Li Si"));
            }
        }
    }
}
