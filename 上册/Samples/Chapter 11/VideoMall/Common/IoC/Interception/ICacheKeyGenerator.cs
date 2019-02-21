using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Artech.VideoMall.Common
{
   public  interface ICacheKeyGenerator
    {
        string CreateCacheKey(MethodBase method, object[] inputs);
    }
}
