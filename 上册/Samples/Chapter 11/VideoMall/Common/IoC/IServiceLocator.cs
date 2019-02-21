using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artech.VideoMall.Common
{
public interface IServiceLocator
{
    T GetService<T>();
    T GetService<T>(string name);
    IEnumerable<T> GetAllService<T>();

    object GetService(Type type);
    object GetService(Type type, string name);
    IEnumerable<object> GetAllService(Type type);
}
}
