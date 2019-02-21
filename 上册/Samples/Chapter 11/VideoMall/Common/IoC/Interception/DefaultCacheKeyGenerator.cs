using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Artech.VideoMall.Common
{
    public class DefaultCacheKeyGenerator : ICacheKeyGenerator
    {
        private readonly Guid KeyGuid = new Guid("ECFD1B0F-0CBA-4AA1-89A0-179B636381CA");       
        public string CreateCacheKey(MethodBase method, params object[] inputs)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}:", KeyGuid);
            if (method.DeclaringType != null)
            {
                sb.Append(method.DeclaringType.FullName);
            }
            sb.Append(':');
            sb.Append(method.Name);

            if (inputs != null)
            {
                foreach (object input in inputs)
                {
                    sb.Append(':');
                    if (input != null)
                    {
                        sb.Append(input.GetHashCode().ToString());
                    }
                }
            }

            return sb.ToString();
        }
    }
}
