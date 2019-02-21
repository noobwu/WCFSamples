using Artech.VideoMall.Common;
using Artech.VideoMall.Orders.BusinessEntity;
using Artech.VideoMall.Orders.DataAccess;
using Artech.VideoMall.Products.Service.Interface;
namespace Artech.VideoMall.Orders.BusinessComponent
{
    public class OrdersBC: BusinessComponentBase<OrdersDA>
    {
        public IProductsService ProductsService { get; private set; }
        public OrdersBC(OrdersDA da, IProductsService productsService)
            : base(da)
        {
            this.ProductsService = productsService;
        }
        public void Submit(Order order)
        {
            this.ValidateStock(order);
            this.DataAccess.Submit(order);
        }
        private void ValidateStock(Order order)
        {
            foreach (OrderLine orderLine in order.OrderLines)
            {
                if (this.ProductsService.GetStock(orderLine.ProductId) < orderLine.Quantity)
                { 
                    throw new OrdersException(string.Format("库存不足[ID:{0}]",orderLine.ProductId));
                }
            }
        }
    }
}
