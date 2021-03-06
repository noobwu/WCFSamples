﻿using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ServiceModel;
namespace Artech.MetadataExporting
{
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface IOrderService
    {
        [OperationContract]
        void ProcessOrder(Order order);
    }

    [DataContract(Namespace = "http://www/artech.com/types/")]
    public class Order
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public Collection<OrderDetail> Details { get; set; }
    }

    [DataContract(Namespace = "http://www/artech.com/types/")]
    public class OrderDetail
    {
        [DataMember]
        public string OrderId { get; set; }
        [DataMember]
        public string ProductId { get; set; }
        [DataMember]
        public int Quantity { get; set; }
    }
}
