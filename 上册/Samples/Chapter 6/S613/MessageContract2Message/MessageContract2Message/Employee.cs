using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Artech.MessageContract2Message
{
    [MessageContract(IsWrapped = false)]
    public class Employee
    {
        [MessageHeader]
        public string Id { get; set; }
        [MessageBodyMember]
        public string Name { get; set; }
        [MessageBodyMember]
        public string Gender { get; set; }
        [MessageBodyMember]
        public string Department { get; set; }
    }
}
