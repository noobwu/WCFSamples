using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Artech.CreateMessage
{
    [DataContract(Namespace = "http://www.artech.com")]
    public class Order
    {
        [DataMember(Name = "OrderNo", Order = 1)]
        public Guid ID { get; set; }
        [DataMember(Name = "OrderDate", Order = 2)]
        public DateTime Date { get; set; }
        [DataMember(Order = 3)]
        public string Customer { get; set; }
        [DataMember(Order = 4)]
        public string ShipAddress { get; set; }
    }
}
