using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Artech.CustomServiceHost
{
public class MexServiceHost: ServiceHost
{
    private string httpGetUrl;
    public MexServiceHost(Type serviceType, string httpGetUrl, params Uri[] baseAddresses)
        : base(serviceType, baseAddresses)
    {
        this.httpGetUrl = httpGetUrl;
    }
    protected override void OnOpening()
    {
        base.OnOpening();
        Uri httpGetUrl = new Uri(this.httpGetUrl,  UriKind.RelativeOrAbsolute);
        if (!httpGetUrl.IsAbsoluteUri)
        {
            Uri baseAddress = (from address in this.BaseAddresses
                                where address.Scheme == Uri.UriSchemeHttp
                                select address).FirstOrDefault();
            if (null == baseAddress)
            {
                return;
            }
            httpGetUrl = new Uri(baseAddress, httpGetUrl);
        }
            
        ServiceMetadataBehavior mexBehavior = this.Description.Behaviors.Find<ServiceMetadataBehavior>();
        if (null == mexBehavior)
        {
            mexBehavior = new ServiceMetadataBehavior();
            this.Description.Behaviors.Add(mexBehavior);
        }
        mexBehavior.HttpGetEnabled  = true;
        mexBehavior.HttpGetUrl      = httpGetUrl;
    }
}
}
