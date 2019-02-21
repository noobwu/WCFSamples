using System;
using System.Diagnostics;
namespace Artech.WcfServices.Service
{
public class Global : System.Web.HttpApplication
{
    void Application_BeginRequest(object sender, EventArgs e)
    {
        Trace.WriteLine("BeginRequest事件被触发！");
    }
    void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        Trace.WriteLine("AuthenticateRequest事件被触发！");
    }
    void Application_PostAuthenticateRequest(object sender, EventArgs e)
    {
        Trace.WriteLine("PostAuthenticateRequest事件被触发！");
    }
}
}