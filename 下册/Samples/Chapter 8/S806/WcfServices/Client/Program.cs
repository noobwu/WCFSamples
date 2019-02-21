using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Net;
using Artech.WcfServices.Service.Interface;
using System.Security.Cryptography.X509Certificates;

namespace Client
{
    class Program
    {
        static void Invoke(Action<ICalculator> action, ICalculator proxy, string operation)
        {
            try
            {
                action(proxy);
                Console.WriteLine("服务操作\"{0}\"调用成功...", operation);
            }
            catch (Exception ex)
            {
                Console.WriteLine("服务操作\"{0}\"调用失败...", operation);
            }
        }


        static void Main(string[] args)
        {
ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorService");
NetworkCredential credential = channelFactory.Credentials.Windows.ClientCredential;
credential.UserName = "Foo";
credential.Password = "Password";
ICalculator calculator = channelFactory.CreateChannel();
Invoke(proxy => proxy.Add(1, 2), calculator, "Add");
Invoke(proxy => proxy.Subtract(1, 2), calculator, "Subtract");
Invoke(proxy => proxy.Multiply(1, 2), calculator, "Multiply");
Invoke(proxy => proxy.Divide(1, 2), calculator, "Divide");
Console.WriteLine();

channelFactory = new ChannelFactory<ICalculator>("calculatorService");
credential = channelFactory.Credentials.Windows.ClientCredential;
credential.UserName = "Bar";
credential.Password = "Password";
calculator = channelFactory.CreateChannel();
Invoke(proxy => proxy.Add(1, 2), calculator, "Add");
Invoke(proxy => proxy.Subtract(1, 2), calculator, "Subtract");
Invoke(proxy => proxy.Multiply(1, 2), calculator, "Multiply");
Invoke(proxy => proxy.Divide(1, 2), calculator, "Divide");

            Console.Read();
        }
    }
}
