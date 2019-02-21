using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
using (ChannelFactory<IMessenger> channelFactory = new ChannelFactory<IMessenger>("messengerservice"))
{
    string message = new string('a',1000);
    IMessenger messenger = channelFactory.CreateChannel();
    messenger.Send(message);
}
            Console.Read();
        }
    }
}
