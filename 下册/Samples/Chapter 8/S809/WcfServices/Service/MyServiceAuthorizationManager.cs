using System.ServiceModel;
namespace Artech.WcfServices.Service
{
    public class MyServiceAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            string userName = operationContext.ServiceSecurityContext.PrimaryIdentity.Name;
            return  string.Compare(userName, @"Jinnan-PC\Foo",true) == 0;
        }
    }
}
