using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;
namespace Artech.Serialization
{
    public interface IOrder
    {
        Guid ID { get; set; }
        DateTime Date { get; set; }
        string Customer { get; set; }
        string ShipAddress { get; set; }
    }
    [DataContract]
    public abstract class OrderBase : IOrder
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
    [DataContract]
    public class Order : OrderBase
    {
        [DataMember]
        public double TotalPrice { get; set; }
    }


}
