using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Net.Security;

namespace Artech.MessageContractOperation
{
[MessageContract(IsWrapped = false, ProtectionLevel = ProtectionLevel.Sign)]
public class Employee
{
    [MessageHeader(Name = "EmployeeId")]
    public string Id { get; set; }
    [MessageBodyMember(Name = "EmployeeName", Order = 1)]
    public string Name { get; set; }
    [MessageBodyMember(Name = "Sex", Order = 2)]
    public string Gender { get; set; }
    [MessageBodyMember(Name = "Dept", Order = 1)]
    public string Department { get; set; }
}
}
