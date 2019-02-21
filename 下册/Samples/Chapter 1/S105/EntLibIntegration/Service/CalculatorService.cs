using System.ServiceModel;
using Artech.EntLibIntegration.Service.Interface;
namespace Artech.EntLibIntegration.Service
{
[ExceptionHandlingBehavior("service policy")]
public class CalculatorService : ICalculator
{
    public int Divide(int x, int y)
    {
        return x / y;
    }
}
} 