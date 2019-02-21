using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.ServiceHosting.Service.Interface;

namespace Artech.ServiceHosting.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/", 
                     ConfigurationName = "IFoo")]
    public interface IFoo
    {
        [OperationContract]
        void DoSth();
    }
    [ServiceContract(Namespace = "http://www.artech.com/",
                      ConfigurationName = "IBar")]
    public interface IBar
    {
        [OperationContract]
        void DoSth();
    }
    [ServiceContract(Namespace = "http://www.artech.com/",
                     ConfigurationName = "IBaz")]
    public interface IBaz
    {
        [OperationContract]
        void DoSth();
    }
}
namespace Artech.ServiceHosting.Service
{
    [ServiceBehavior(ConfigurationName="FooService")]
    public class FooService : IFoo
    {
        public void DoSth() { }
    }
    [ServiceBehavior(ConfigurationName = "BarService")]
    public class BarService : IBar
    {
        public void DoSth() { }
    }
    [ServiceBehavior(ConfigurationName = "BazService")]
    public class BazService : IBaz
    {
        public void DoSth() { }
    }


}
