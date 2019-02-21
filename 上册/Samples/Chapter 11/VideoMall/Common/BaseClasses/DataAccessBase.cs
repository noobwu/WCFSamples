using System;
namespace Artech.VideoMall.Common
{
    public abstract class DataAccessBase: MarshalByRefObject
    {
        public virtual DbHelper Helper
        {
            get { return ServiceLocatorFactory.GetServiceLocator().GetService<DbHelper>();}
        }
    }
}