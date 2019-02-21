using System;
using System.ServiceModel;
using System.Transactions;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Service
{
    [ServiceBehavior(ReleaseServiceInstanceOnTransactionComplete = false)]
    public class GreetingService : IGreeting
    {
        [OperationBehavior(TransactionScopeRequired = true)]
        public void SayHello(string name)
        {
            Console.WriteLine("[{1}]Hello, {0}", name,Transaction.Current.TransactionInformation.DistributedIdentifier);
        }
        [OperationBehavior(TransactionScopeRequired = true)]
        public void SayGoodbye(string name)
        {
            Console.WriteLine("[{1}]Goodbye, {0}", name, Transaction.Current.TransactionInformation.DistributedIdentifier);
        }
    }
}