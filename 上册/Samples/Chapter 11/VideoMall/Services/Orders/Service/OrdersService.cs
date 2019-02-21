using System.ServiceModel;
using Artech.VideoMall.Common;
using Artech.VideoMall.Orders.BusinessComponent;
using Artech.VideoMall.Orders.BusinessEntity;
using Artech.VideoMall.Orders.Service.Interface;
using Microsoft.Practices.Unity.Utility;
namespace Artech.VideoMall.Orders.Service
{
    [ServiceBehavior(Namespace = Constants.ServiceNamespace)]
   public class OrdersService: ServiceBase<OrdersBC>,IOrdersService
   {
       public OrdersService(OrdersBC bc)
           : base(bc)
       { }
       [OperationBehavior(TransactionScopeRequired = true)]
        public void Submit(Order order)
        {
            Guard.ArgumentNotNull(order, "order");
            this.Business.Submit(order);
        }
    }
}
