using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Collections;
namespace Artech.Serialization
{
    public class Contact
    {
        public string FullName { get; set; }
        public string Sex { get; set; }
    }

    [DataContract(Namespace = "http://www.artech.com")]
    public class Customer
    {
        [DataMember(Order = 1)]
        public string FirstName { get; set; }
        [DataMember(Order = 2)]
        public string LastName { get; set; }
        [DataMember(Order = 3)]
        public string Gender { get; set; }
    }
}