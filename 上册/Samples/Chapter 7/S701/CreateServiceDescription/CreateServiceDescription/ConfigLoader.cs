using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;
using System.Configuration;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Reflection;

namespace CreateServiceDescription
{
public static class ConfigLoader
{
    private static Dictionary<string, Type> bindingTable;
    static ConfigLoader()
    {
        bindingTable = new Dictionary<string, Type>();
        bindingTable.Add("basicHttpBinding", typeof(BasicHttpBinding));
        bindingTable.Add("wsHttpBinding", typeof(WSHttpBinding));
        bindingTable.Add("ws2007HttpBinding", typeof(WS2007HttpBinding));
        bindingTable.Add("netTcpBinding", typeof(NetTcpBinding));
        //...
    }
    public static ServiceElement GetServiceElement(string serviceName)
    {
        ServicesSection servicesSection =  ConfigurationManager.GetSection("system.serviceModel/services") as ServicesSection;
        for (int i = 0; i < servicesSection.Services.Count; i++)
        {
            if (servicesSection.Services[i].Name == serviceName)
            {
                return  servicesSection.Services[i];
            }
        }
        throw new IndexOutOfRangeException();
    }
    public static ServiceBehaviorElement GetServiceBehaviorElement(string behaviorname)
    {
        BehaviorsSection behaviorsSection =  ConfigurationManager.GetSection("system.serviceModel/behaviors") as BehaviorsSection;
        return behaviorsSection.ServiceBehaviors[behaviorname];
    }
    public static EndpointBehaviorElement GetEndpointBehaviorElement(string behaviorname)
    {
        BehaviorsSection behaviorsSection = ConfigurationManager.GetSection("system.serviceModel/behaviors") as BehaviorsSection;
        return behaviorsSection.EndpointBehaviors[behaviorname];
    }
    public static Binding CreateBinding(string bindingName)
    {
        return (Binding)Activator.CreateInstance(bindingTable[bindingName]);
    }
    public static object CreateBehavior(this BehaviorExtensionElement behaviorExtensionElement)
    {
        BindingFlags flags =  BindingFlags.Instance | BindingFlags.NonPublic;
        MethodInfo createBehavior = typeof(BehaviorExtensionElement).GetMethod("CreateBehavior", flags);
        return createBehavior.Invoke(behaviorExtensionElement, null);
    }
}
}
