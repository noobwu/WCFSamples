using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Collections;
namespace Artech.Serialization
{
    //CustomerV2
    [DataContract(Name = "Customer", Namespace = "http://www.artech.com")]
    public class CustomerV1
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
    }

    //CustomerV2
    [DataContract(Name = "Customer", Namespace = "http://www.artech.com")]
    public class CustomerV2
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember(IsRequired = true)]
        public string Address { get; set; }
    }
}