using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
    public interface ICalculatorCallback
    {
        [OperationContract]
        void DisplayResult(double result, double x, double y);
    }
}
