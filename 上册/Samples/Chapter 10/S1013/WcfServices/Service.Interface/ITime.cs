using System;
using System.ServiceModel;
using System.ServiceModel.Web;
namespace Artech.WcfServices.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface ITime
    {
        [WebGet(UriTemplate = "/current")]
        [AspNetCacheProfile("default")]
        DateTime GetCurrentTime();
    }
}
