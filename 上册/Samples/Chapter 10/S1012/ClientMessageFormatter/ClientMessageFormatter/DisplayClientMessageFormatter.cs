using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.Reflection;

namespace Artech.WebHttpModel
{
public class DisplayClientMessageFormatterAttribute : Attribute, IOperationBehavior
{
    private object GetField(object target, string fieldName)
    {
        Type type = target.GetType();
        FieldInfo field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        return field.GetValue(target);
    }

    public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
    {

    }

    public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
    {
        Console.WriteLine("{0}: ", clientOperation.Name);
        IClientMessageFormatter formatter = clientOperation.Formatter;
        Console.WriteLine("\t{0}", formatter.GetType().Name);

        if (formatter.GetType().Name != "CompositeClientFormatter")
        {
            return;
        }
        object innerFormatter = this.GetField(formatter, "reply");
        Console.WriteLine("\t\t{0}", innerFormatter.GetType().Name);

        if (innerFormatter.GetType().Name == "DemultiplexingClientMessageFormatter")
        {
            Dictionary<WebContentFormat, IClientMessageFormatter> formatters = this.GetField(innerFormatter,"formatters") as Dictionary<WebContentFormat, IClientMessageFormatter>;
            Console.WriteLine("\t\t\t{0, -4}: {1}", "Xml", formatters[WebContentFormat.Xml].GetType().Name);
            Console.WriteLine("\t\t\t{0, -4}: {1}", "Json", formatters[WebContentFormat.Json].GetType().Name);
        }

    }

    public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
    {

    }

    public void Validate(OperationDescription operationDescription)
    {

    }
}
}
