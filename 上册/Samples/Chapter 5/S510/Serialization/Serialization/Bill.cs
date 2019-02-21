using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;
namespace Artech.Serialization
{
    [DataContract(Namespace = "http://www.artech.com/")]
    public class Bill<BillHeader, BillDetail>
    {
        [DataMember(Order = 1)]
        public BillHeader Header { get; set; }
        [DataMember(Order = 2)]
        public BillDetail[] Details { get; set; }
    }
    [DataContract(Namespace = "http://www.artech.com/")]
    public class OrderBillHeader
    {
        [DataMember]
        public Guid OrderID { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Customer { get; set; }
    }
    [DataContract(Namespace = "http://www.artech.com/")]
    public class OrderBillDetail
    {
        [DataMember]
        public Guid ProductID { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public double UnitPrice { get; set; }
    }
}