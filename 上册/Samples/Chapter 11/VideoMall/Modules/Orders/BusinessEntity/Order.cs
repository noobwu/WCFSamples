using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Artech.VideoMall.Common;
using Microsoft.Practices.Unity.Utility;
namespace Artech.VideoMall.Orders.BusinessEntity
{
    [DataContract(Namespace = Constants.DataContractNamespace)]
    public class Order
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public IList<OrderLine> OrderLines { get; private set; }
        public Order(string id, DateTime date, string userName)
        {
            Guard.ArgumentNotNullOrEmpty(id, "id");
            Guard.ArgumentNotNullOrEmpty(userName, "userName");
            this.Id = id;
            this.Date = date;
            this.UserName = userName;
            this.OrderLines = new List<OrderLine>();
        }
        public void AddOrderLine(string productId, int quantity)
        {
            Guard.ArgumentNotNullOrEmpty(productId, "productId");
            this.OrderLines.Add(new OrderLine
            {
                ProductId = productId,
                Quantity = quantity
            });
        }
    }
    [DataContract(Namespace = Constants.DataContractNamespace)]
    public class OrderLine
    {
        [DataMember]
        public string ProductId { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}
