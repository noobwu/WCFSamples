using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Artech.XmlEncoding
{
[DataContract(Namespace ="http://www.artech.com/")]
public class Employee
{
    [DataMember(Order = 1)]
    public string Id { get; set; }
    [DataMember(Order = 2)]
    public string Name { get; set; }
    [DataMember(Order = 3)]
    public string Gender { get; set; }
    [DataMember(Order = 4)]
    public string Department { get; set; }
}
}
