using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;
namespace Artech.Serialization
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public Address CompanyAddress { get; set; }
        [DataMember]
        public Address ShipAddress { get; set; }
    }
    [DataContract]
    public class Address
    {
        [DataMember]
        public string Province { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string District { get; set; }
        [DataMember]
        public string Road { get; set; }
    }

}
