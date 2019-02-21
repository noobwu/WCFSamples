using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface IHello
    {
        [OperationContract]
        string SayHello(string userName);
    }
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface IGoodbye
    {
        [OperationContract]
        string SayGoodbye(string userName);
    }
}
