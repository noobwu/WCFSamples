using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Description;
using System.Threading;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
using (ChannelFactory<ITime> channelFactory = new ChannelFactory<ITime>("timeService"))
{
    ITime proxy = channelFactory.CreateChannel();
    for (int i = 0; i < 5; i++)
    { 
        Console.WriteLine(proxy.GetCurrentTime().ToLongTimeString());
        Thread.Sleep(1000);
    }
}
            Console.Read();
        }

    }
}

