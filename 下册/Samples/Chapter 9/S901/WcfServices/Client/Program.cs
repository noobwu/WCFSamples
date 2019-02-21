using System;
using System.ServiceModel;
using System.Threading;
using Artech.WcfServices.Service.Interface;
using System.Globalization;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
using (ChannelFactory<IResourceService> channelFactory = new ChannelFactory<IResourceService>("resourceservice"))
{
    IResourceService proxy = channelFactory.CreateChannel();
    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
    Console.WriteLine(proxy.GetString("HappyNewYear"));
    Console.WriteLine(proxy.GetString("MerryChristmas") + "\n");

    Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
    Console.WriteLine(proxy.GetString("HappyNewYear"));
    Console.WriteLine(proxy.GetString("MerryChristmas"));
}
            Console.Read();

        }
    }
}
