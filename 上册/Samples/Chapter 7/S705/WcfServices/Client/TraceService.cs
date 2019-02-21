using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.WcfServices.Service.Interface;

namespace Artech.WcfServices.Client
{
public class TraceService: ITrace
{
    public void Write(string message)
    {
        Console.Write(message);
    }
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}
}
