using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class CalculatorService : ICalculator
    {
        public void Add(double x, double y)
        {
            double result = x + y;
            ICalculatorCallback callback =
                OperationContext.Current.GetCallbackChannel<ICalculatorCallback>();
            callback.DisplayResult(result, x, y);
        }
    }
}
