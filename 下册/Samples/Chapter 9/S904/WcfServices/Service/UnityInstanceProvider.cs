using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;
namespace Artech.WcfServices.Service
{
    public class UnityInstanceProvider : IInstanceProvider
    {
        public IUnityContainer UnityContainer { get; private set; }
        public Type ContractType { get; private set; }

        public UnityInstanceProvider(IUnityContainer unityContainer, Type contractType)
        {
            this.UnityContainer = unityContainer;
            this.ContractType = contractType;
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this.UnityContainer.Resolve(this.ContractType);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            this.UnityContainer.Teardown(instance);
        }
    }
}
