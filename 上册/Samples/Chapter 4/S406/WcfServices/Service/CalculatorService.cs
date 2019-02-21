using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.Threading;
namespace Artech.WcfServices.Service
{
    public class CalculatorService : ICalculator
    {
        public void Add(double x, double y)
        {
            double result = x + y;
            ICalculatorCallback callback = OperationContext.Current.GetCallbackChannel<ICalculatorCallback>();
            callback.DisplayResult(result, x, y);
        }
    }
}
