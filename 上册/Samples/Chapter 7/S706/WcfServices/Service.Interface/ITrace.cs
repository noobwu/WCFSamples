using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Artech.WcfServices.Service.Interface
{
[ServiceContract(Namespace ="http://www.artech.com")]
public interface ITrace
{
    [OperationContract(IsOneWay = true)]
    void Write(string message);

    [OperationContract(IsOneWay = true)]
    void WriteLine(string message);
}
}
