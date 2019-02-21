using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
using System;
using System.ServiceModel.Channels;
namespace Artech.WcfServices.Service
{
[ServiceBehavior(TransactionAutoCompleteOnSessionClose = true)]
public class GreetingService : IGreeting
{
    [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
    public void SayHello(string name)
    {           
        MsmqMessageProperty msmqMessageProperty = OperationContext.Current.GetMsmqMessageProperty();
        Console.WriteLine("{0,-11}: {1}", "AbortCount", msmqMessageProperty.AbortCount);
        Console.WriteLine("{0,-11}: {1}", "MoveCount", msmqMessageProperty.MoveCount);
        throw new Exception();
    }
    [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
    public void SayGoodbye(string name)
    {
        Console.WriteLine("Goodbye, {0}", name);
    }
}
}