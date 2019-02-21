using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
[ServiceContract(Namespace ="http://www.artech.com/")]
public interface ICalculator
{
    [OperationContract]
    int Add(int x, int y);
    [OperationContract]
    int Subtract(int x, int y);
    [OperationContract]
    int Multiply(int x, int y);
    [OperationContract]
    int Divide(int x, int y);
}
}