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
                throw new FaultException("被除数y不能为零!");
            }
            return x / y;

        }
    }
}
