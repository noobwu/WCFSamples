using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface IGreeting
    {
        [OperationContract(IsOneWay = true)]
        void SayHello(string name);
        [OperationContract(IsOneWay = true)]
        void SayGoodbye(string name);
    }
}