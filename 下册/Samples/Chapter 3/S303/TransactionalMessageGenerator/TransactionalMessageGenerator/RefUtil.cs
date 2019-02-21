using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Globalization;

namespace TransactionalMessageGenerator
{
    public static class RefUtil
    {    
        public static T CreateInstance<T>(string typeQname) where T : class
        {
            Type type = Type.GetType(typeQname);
            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            ConstructorInfo constructorInfo = type.GetConstructor(bindingFlags, Type.DefaultBinder, Type.EmptyTypes, null);
            return Activator.CreateInstance(type, bindingFlags, Type.DefaultBinder,new object[0], CultureInfo.InvariantCulture) as T;  
        }

        public static void Invoke(Type type, string methodName, object target, object[] parameters)
        {
            MethodInfo method = type.GetMethod(methodName);
            method.Invoke(target, parameters);
        }

        public static void Invoke(string methodName, object target,  object[] parameters)
        {
            Invoke(target.GetType(), methodName, target, parameters);
        }
    }
}
