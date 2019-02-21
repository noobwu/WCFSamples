using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace System
{
    public static class Extensions
    {
        public static void Print(object obj, string methodName)
        {
            Console.WriteLine("{0}.{1}", obj.GetType().Name, methodName);
        }
    }
}