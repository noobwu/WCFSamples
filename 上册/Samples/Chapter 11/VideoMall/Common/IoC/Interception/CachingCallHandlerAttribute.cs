using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.Unity;

namespace Artech.VideoMall.Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Method)]
    public class CachingCallHandlerAttribute : HandlerAttribute
    {
        public TimeSpan ExpirationTime{get; private set;}
        
        public CachingCallHandlerAttribute()
        {
            ExpirationTime = CachingCallHandler.DefaultExpirationTime;
        }
        public CachingCallHandlerAttribute(int hours, int minutes, int seconds)
        {
            ExpirationTime = new TimeSpan(hours, minutes, seconds);
        }        
        public override ICallHandler CreateHandler(IUnityContainer ignored)
        {
            return new CachingCallHandler(ExpirationTime) { Order = this.Order };
        }
    }
}