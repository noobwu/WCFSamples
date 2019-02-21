using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Messaging;
using Artech.WcfServices.Service.Interface;
using System.Transactions;

namespace Message4SessionfulService
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @".\private$\XactQueue4Demo";
            if(!MessageQueue.Exists(path))
            {
                MessageQueue.Create(path, true);
            }
            var queue = new MessageQueue(path);
            queue.Purge();

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
            var message = queue.Receive();
            byte[] buffer = new byte[message.BodyStream.Length];
            message.BodyStream.Read(buffer, 0, buffer.Length);
            Console.WriteLine(Encoding.Default.GetString(buffer));
        }
    }
}
