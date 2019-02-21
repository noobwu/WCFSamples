using System.ServiceModel;
using System.ServiceModel.Channels;
using System;
using System.Collections.Generic;
using System.Reflection;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/")]    
    public interface ICalculator
    {
        [OperationContract]
        double Add(double x, double y);
    }
}


