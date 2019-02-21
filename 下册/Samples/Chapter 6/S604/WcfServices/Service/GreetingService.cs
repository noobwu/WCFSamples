using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
using System;
namespace Artech.WcfServices.Service
{
    [ServiceBehavior(TransactionAutoCompleteOnSessionClose = true)]
    public class GreetingService : IGreeting
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void SayHello(string name)
        {
            Console.WriteLine("Hello, {0}", name);
        }
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void SayGoodbye(string name)
        {
            Console.WriteLine("Goodbye, {0}", name);
        }
    }
}