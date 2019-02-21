using System.ServiceModel;
using System.ServiceModel.Channels;
namespace Artech.WcfServices.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/", CallbackContract = typeof(ICalculatorCallback))]
    public interface ICalculator
    {
        [OperationContract(IsOneWay = true)]
        void Add(double x, double y);
    }
}
