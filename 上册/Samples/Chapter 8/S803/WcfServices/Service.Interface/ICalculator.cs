using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
[ServiceContract(Namespace ="http://www.artech.com/")]
public interface ICalculator
{
    [OperationContract]
    double Add(double x, double y);
}
}
