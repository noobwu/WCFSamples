using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Utility;

namespace Artech.VideoMall.Common
{
public class UnityServiceLocator: IServiceLocator
{
    public IUnityContainer Container { get; private set; }
    public UnityServiceLocator(IUnityContainer container)
    {
        Guard.ArgumentNotNull(container, "container");
        this.Container = container;
    }
    public UnityServiceLocator(Func<IUnityContainer> createContainer)
    {
        Guard.ArgumentNotNull(createContainer, "createContainer");
        this.Container = createContainer();
    }
    public T GetService<T>()
    {
        return this.Container.Resolve<T>();
    }
    public T GetService<T>(string name)
    {
        return this.Container.Resolve<T>(name);
    }        
    public IEnumerable<T> GetAllService<T>()
    {
        return this.Container.ResolveAll<T>();
    }
    public object GetService(Type type)
    {
        return this.Container.Resolve(type);
    }
    public object GetService(Type type, string name)
    {
        return this.Container.Resolve(type, name);
    }
    public IEnumerable<object> GetAllService(Type type)
    {
        return this.Container.ResolveAll(type);
    }
}
}
