using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface ICalculator
    {
        [OperationContract(Action = "http://www.artech.com/calculator/add")]
        double Add(double x, double y);
        [OperationContract(Action = "http://www.artech.com/calculator/subtract")]
        double Subtract(double x, double y);
        [OperationContract(Action = "http://www.artech.com/calculator/multiply")]
        double Multiply(double x, double y);
        [OperationContract(Action = "http://www.artech.com/calculator/divide")]
        double Divide(double x, double y);
    }
}