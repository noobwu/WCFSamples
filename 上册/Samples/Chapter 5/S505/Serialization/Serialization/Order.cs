using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace Artech.Serialization
{
    [DataContract(Namespace = "http://www.artech.com/")]
    public class OrderBase
    {
        [DataMember(Name = "OrderID", Order = 1)]
        public Guid ID { get; set; }
        [DataMember(Name = "OrderDate", Order = 2)]
        public DateTime Date { get; set; }
        [DataMember(Order = 3)]
        public string Customer { get; set; }
        [DataMember(Order = 4)]
        public string ShipAddress { get; set; }
        public double TotalPrice { get; set; }
    }
    [DataContract(Name = "Ord", Namespace = "http://www.artech.com/")]
    public class Order : OrderBase
    {
        [DataMember(Order = 1)]
        public string PaymentType { get; set; }
    }

}
