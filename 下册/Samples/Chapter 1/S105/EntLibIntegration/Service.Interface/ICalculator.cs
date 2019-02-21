using System.ServiceModel;
namespace Artech.EntLibIntegration.Service.Interface
{    
[ServiceContract(Namespace = "http://www.artech.com/")]
public interface ICalculator
{
    [OperationContract]
    [FaultContract(typeof(ServiceExceptionDetail), Action = ServiceExceptionDetail.FaultAction)]
    int Divide(int x, int y);
}   
}