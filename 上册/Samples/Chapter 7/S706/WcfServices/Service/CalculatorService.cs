using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Activation;
namespace Artech.WcfServices.Service
{
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class CalculatorService : ICalculator
{
    public double Add(double x, double y)
    {
        return x + y;
    }
}
}
