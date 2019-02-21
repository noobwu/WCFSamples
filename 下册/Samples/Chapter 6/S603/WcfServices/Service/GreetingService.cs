using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
using System;
namespace Artech.WcfServices.Service
{    public class GreetingService : IGreeting
    {
        [OperationBehavior(TransactionScopeRequired = true)]
        public void SayHello(string name)
        {
            Console.WriteLine("Hello, {0}", name);
        }
        [OperationBehavior(TransactionScopeRequired = true)]
        public void SayGoodbye(string name)
        {
            Console.WriteLine("Goodbye, {0}", name);
        }
    }
}