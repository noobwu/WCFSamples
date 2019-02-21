using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artech.WcfServices.Service.Interface
{
public class ApplicationContextScope: IDisposable
{
    private ApplicationContext originalContext = ApplicationContext.Current;
    public ApplicationContextScope()
    {
        ApplicationContext.Current = new ApplicationContext();
    }
    public void Dispose()
    {
        ApplicationContext.Current = originalContext;
    }
}
}
