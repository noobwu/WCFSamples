using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
namespace Artech.WcfServices.Service
{
    public class CalculatorService : ICalculator
    {
        public int Divide(int x, int y)
        {
            if (0 == y)
            {
                var error = new CalculationError("Divide", "被除数y不能为零!");
                throw new FaultException<CalculationError>(error, error.Message);
            }
            return x / y;
        }
    }
}