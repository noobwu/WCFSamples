using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
    public interface ICalculatorCallback
    {
        [OperationContract(IsOneWay = true)]
        void DisplayResult(double result, double x, double y);
    }
}
