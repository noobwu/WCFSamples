using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity.Utility;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace Artech.VideoMall.Common
{
public static class ServiceLocatorFactory
{
    private static Func<string, IServiceLocator> createServiceLocator;
    public static void RegisterServiceFactory(Func<string, IServiceLocator> buildServiceLocator)
    {
        Guard.ArgumentNotNull(buildServiceLocator, "createServiceLocator");
        createServiceLocator = buildServiceLocator;
    }
    static Dictionary<string, IUnityContainer> containers = new Dictionary<string, IUnityContainer>();
    static ServiceLocatorFactory()
    {
        createServiceLocator = name =>
            {
                IUnityContainer container;
                name = name ?? string.Empty;
                if (!containers.ContainsKey(name))
                {
                    container = new UnityContainer();
                    UnityConfigurationSection config = ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) as UnityConfigurationSection;
                    if (null != config)
                    {
                        if (string.IsNullOrEmpty(name))
                        {
                            config.Configure(container);
                        }
                        else
                        {
                            config.Configure(container, name);
                        }
                    }
                    lock (createServiceLocator)
                    {
                        containers[name] = container;
                    }
                }
                else
                {
                    container = containers[name];
                }
                return new UnityServiceLocator(container);
            };
    }
    public static IServiceLocator GetServiceLocator(string name = "")
    {
        return createServiceLocator(name);
    }
}
}
