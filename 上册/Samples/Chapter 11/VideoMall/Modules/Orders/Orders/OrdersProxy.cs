using Artech.VideoMall.Common;
using Artech.VideoMall.Orders.BusinessEntity;
using Artech.VideoMall.Orders.Service.Interface;
namespace Artech.VideoMall.Orders
{
    public class OrdersProxy : ServiceProxyBase<IOrdersService>, IOrdersService
    {
        public OrdersProxy()
            : base("ordersService")
        { }
        public void Submit(Order order)
        {
            this.Invoker.Invoke(proxy => proxy.Submit(order));
        }
    }
}
