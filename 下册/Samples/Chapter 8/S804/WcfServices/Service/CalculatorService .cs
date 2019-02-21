using System.Security.Permissions;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Service
{
    public class CalculatorService : ICalculator
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        public double Add(double x, double y)
        {
            return x + y;
        }
    }
}
