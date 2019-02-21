using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.Threading;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<IResourceService> channelFactory = new ChannelFactory<IResourceService>("resourceservice"))
            {
                IResourceService proxy = channelFactory.CreateChannel();
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                Console.WriteLine(proxy.GetString("HappyNewYear"));
                Console.WriteLine(proxy.GetString("MerryChristmas") + "\n");

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
                Console.WriteLine(proxy.GetString("HappyNewYear"));
                Console.WriteLine(proxy.GetString("MerryChristmas"));
            }
            Console.Read();

        }
    }
}
