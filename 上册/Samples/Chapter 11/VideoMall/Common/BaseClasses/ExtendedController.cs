using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.Practices.Unity.Utility;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Artech.VideoMall.Common.Extensions
{
    public abstract class ExtendedController : Controller
    {
        public static string DefautExceptionPolicyName { get; private set; }
        public string ExceptionPolicyName { get; private set; }

        public static void RegisterExceptionPolicy(string exceptionPolicyName)
        {
            Guard.ArgumentNotNullOrEmpty(exceptionPolicyName, "exceptionPolicyName");
            DefautExceptionPolicyName = exceptionPolicyName;
        }

        public ExtendedController(string exceptionPolicyName = "")
        {
            this.ExceptionPolicyName = exceptionPolicyName;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            string exceptionPolicy = this.ExceptionPolicyName;
            if (string.IsNullOrEmpty(exceptionPolicy))
            {
                exceptionPolicy = DefautExceptionPolicyName;
            }
            try
            {
                if (ExceptionPolicy.HandleException(filterContext.Exception, exceptionPolicy))
                {
                    base.OnException(filterContext);
                }
                else
                {
                    this.ModelState.AddModelError(Guid.NewGuid().ToString(), filterContext.Exception);
                    filterContext.Result = this.View();
                }
            }
            catch (Exception ex)
            {
                filterContext.Exception = ex;
                base.OnException(filterContext);
            }
        }
    }
}
