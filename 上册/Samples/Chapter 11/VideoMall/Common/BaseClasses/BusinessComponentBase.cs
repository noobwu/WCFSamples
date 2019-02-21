using System;
namespace Artech.VideoMall.Common
{
    public abstract class BusinessComponentBase: MarshalByRefObject
    {}
    public abstract class BusinessComponentBase<TDataAccess> : BusinessComponentBase
    {
        public TDataAccess DataAccess { get; private set; }
        protected BusinessComponentBase(TDataAccess dataAccess)
        {
            this.DataAccess = dataAccess;
        }
    }
}
