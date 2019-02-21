using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;

namespace Artech.VideoMall.Common.Extensions
{
public class ServiceLocatableControllerFactory : DefaultControllerFactory
{
    public string ServiceLocatorName { get; private set; }

    public ServiceLocatableControllerFactory(string serviceLocatorName = "")
    {
        this.ServiceLocatorName = serviceLocatorName;
    }
    protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
    {
        return (IController)ServiceLocatorFactory.GetServiceLocator(ServiceLocatorName).GetService(controllerType);
    }
}
}
