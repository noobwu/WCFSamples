using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;
namespace Artech.Serialization
{
    [DataContract(Namespace = "http://www.artech.com/")]
    public class Customer
    {
        [DataMember(Order = 1)]
        public Guid ID { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
        [DataMember(Order = 3)]
        public string Phone { get; set; }
        [DataMember(Order = 4)]
        public string CompanyAddress { get; set; }
    }

}