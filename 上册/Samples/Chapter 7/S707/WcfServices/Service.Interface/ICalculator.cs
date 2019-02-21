using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
[ServiceContract(Namespace ="http://www.artech.com/")]
public interface ICalculator
{
    [OperationContract]
    void Add(double x);
    [OperationContract]
    void Subtract(double x);
    [OperationContract]
    void Multiply(double x);
    [OperationContract]
    void Divide(double x);
    [OperationContract]
    double GetResult();
}
}
