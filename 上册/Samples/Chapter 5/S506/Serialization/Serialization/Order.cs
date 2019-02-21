using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;
namespace Artech.Serialization
{
    public class OrderCollection : List<Order> { }
    [DataContract]
    public class Order
    {
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Customer { get; set; }
        [DataMember]
        public string ShipAddress { get; set; }
    }
}
