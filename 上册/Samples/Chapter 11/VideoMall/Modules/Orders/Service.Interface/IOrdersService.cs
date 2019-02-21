using System.ServiceModel;
using Artech.VideoMall.Common;
using Artech.VideoMall.Orders.BusinessEntity;
namespace Artech.VideoMall.Orders.Service.Interface
{
    [ServiceContract(Namespace = Constants.ServiceContractNamespace)]
    public interface IOrdersService
    {
        [OperationContract]
        void Submit(Order order);
    }
}