using System.ServiceModel;
using Artech.WcfServices.Service;
using System;
using System.Web.Security;
namespace Artech.WcfServices.Service
{
    public class Program
    {
        static void Main(string[] args)
        {
            if (!Roles.RoleExists("Administrators"))
            {
                Roles.CreateRole("Administrators");
            }
            if (!Roles.IsUserInRole(@"Jinnan-PC\Foo", "Administrators"))
            {
                Roles.AddUserToRole(@"Jinnan-PC\Foo", "Administrators");
            }
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Open();
                Console.Read();
            }

        }
    }
}
