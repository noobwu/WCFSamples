using Artech.VideoMall.Common;
using Artech.VideoMall.Orders.BusinessEntity;
namespace Artech.VideoMall.Orders.DataAccess
{
    public class OrdersDA: DataAccessBase
    {
        public void Submit(Order order)
        {
            this.Helper.ExecuteNonQuery("P_ORDER_I", order.Id, order.Date, order.UserName);
            foreach (var orderLine in order.OrderLines)
            {
                this.Helper.ExecuteNonQuery("P_ORDER_LINE_I", order.Id, orderLine.ProductId, orderLine.Quantity);
            }
        }
    }
}
