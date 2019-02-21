using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Service
{
    public class CalculatorService : ICalculator
    {
        public int Divide(int x, int y)
        {
            return x / y;
        }
    }
}
