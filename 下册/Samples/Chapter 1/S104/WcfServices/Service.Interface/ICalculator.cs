using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface ICalculator
    {
        [OperationContract]
        [FaultContract(typeof(CalculationError))]
        int Divide(int x, int y);
    }   
}
