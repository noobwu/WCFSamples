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
            if (!Roles.IsUserInRole("CN=Foo; 50819320DAAF1BAD9DE8823D3216BE9B36760C4D", "Administrators"))
            {
                Roles.AddUserToRole("CN=Foo; 50819320DAAF1BAD9DE8823D3216BE9B36760C4D", "Administrators");
            }
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Open();
                Console.Read();
            }
        }
    }
}
