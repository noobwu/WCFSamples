using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel;

namespace Artech.WcfServices.Service
{
    public class MexServiceHostFactory:ServiceHostFactory
    {
        private string httpUrl;
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            string[] strArray = constructorString.Split(';');
            string serviceType = strArray[0];
            httpUrl = strArray[1];
            return base.CreateServiceHost(serviceType, baseAddresses);
        }
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new MexServiceHost(serviceType, httpUrl, baseAddresses);
        }
    }
}
