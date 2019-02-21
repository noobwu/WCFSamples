using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.InterceptionExtension;
using System.Web;
using System.Reflection;
using System.Web.Caching;

namespace Artech.VideoMall.Common
{
    public class CachingCallHandler : ICallHandler
    {
        public static readonly TimeSpan DefaultExpirationTime = new TimeSpan(0, 5, 0);

        public ICacheKeyGenerator KeyGenerator { get; private set; }

        public TimeSpan ExpirationTime { get; private set; }

        
        public CachingCallHandler()
            : this(DefaultExpirationTime)
        { }

        public CachingCallHandler(TimeSpan expirationTime)
        {
            KeyGenerator = new DefaultCacheKeyGenerator();
            this.ExpirationTime = expirationTime;
        }

        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            if (TargetMethodReturnsVoid(input))
            {
                return getNext()(input, getNext);
            }

            object[] inputs = new object[input.Inputs.Count];
            for (int i = 0; i < inputs.Length; ++i)
            {
                inputs[i] = input.Inputs[i];
            }

            string cacheKey = KeyGenerator.CreateCacheKey(input.MethodBase, inputs);

            object[] cachedResult = (object[])HttpRuntime.Cache.Get(cacheKey);

            if (cachedResult == null)
            {
                IMethodReturn realReturn = getNext()(input, getNext);
                if (realReturn.Exception == null)
                {
                    AddToCache(cacheKey, realReturn.ReturnValue);
                }
                return realReturn;
            }

            IMethodReturn cachedReturn = input.CreateMethodReturn(cachedResult[0], input.Arguments);
            return cachedReturn;
        }

        private bool TargetMethodReturnsVoid(IMethodInvocation input)
        {
            MethodInfo targetMethod = input.MethodBase as MethodInfo;
            return targetMethod != null && targetMethod.ReturnType == typeof(void);
        }

        private void AddToCache(string key, object value)
        {
            object[] cacheValue = new object[] { value };
            HttpRuntime.Cache.Insert(
                key,
                cacheValue,
                null,
                Cache.NoAbsoluteExpiration,
                ExpirationTime,
                CacheItemPriority.Normal, null);
        }
    }
}
