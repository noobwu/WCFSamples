using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Artech.WcfServices.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface ICalculatorCallback
    {
        [OperationContract]
        void ShowResult(double result);
    }
}
