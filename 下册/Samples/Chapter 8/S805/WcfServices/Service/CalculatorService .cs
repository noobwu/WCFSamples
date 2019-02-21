using System.Security.Permissions;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Description;
namespace Artech.WcfServices.Service
{
    [ServiceAuthorizationBehavior(PrincipalPermissionMode.UseWindowsGroups)]
    public class CalculatorService : ICalculator
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        public double Add(double x, double y)
        {
            return x + y;
        }
    }
}
