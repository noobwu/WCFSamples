using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/")]
    [CulturePropagationBehavior]
    public interface IResourceService
    {
        [OperationContract]
        string GetString(string key);
    }
}
