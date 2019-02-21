using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface ICalculator
    {
        [OperationContract]
        int Divide(int x, int y);
    }   
}
