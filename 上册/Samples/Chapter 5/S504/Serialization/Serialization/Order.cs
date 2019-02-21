using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace Artech.Serialization
{
    [DataContract]
    public class OrderBase
    {
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Customer { get; set; }
        [DataMember]
        public string ShipAddress { get; set; }
        public double TotalPrice { get; set; }
    }
    [DataContract]
    public class Order : OrderBase
    {
        [DataMember]
        public string PaymentType { get; set; }
    }
}
