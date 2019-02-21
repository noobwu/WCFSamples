using System;
namespace Artech.VideoMall.Common
{
    public abstract class ServiceBase: MarshalByRefObject
    {}

    public abstract class ServiceBase<TBusiness> : ServiceBase
    {
        public TBusiness Business { get; private set; }
        public ServiceBase(TBusiness business)
        {
            this.Business = business;
        }
    }
}
