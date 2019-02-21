using System.ServiceModel;
using System.ServiceModel.Channels;
namespace Artech.ServiceMetadataBehaviorSimulator
{
    [ServiceContract(Name = "IHttpGetMetadata", 
                     Namespace = "http://www.artech.com/")]
    public interface IHttpGetMetadata
    {
        [OperationContract(Action = "*", ReplyAction = "*")]
        Message Get(Message msg);
    }
}
