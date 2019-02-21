using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading;

namespace Artech.WcfServices.Service
{
class Program
{
    static  Timer timer = new Timer(state => GC.Collect(), null,0, 100);
    static void Main(string[] args)
    {
        using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
        {
            host.Open();
            Console.Read();
        }
    }
}
}
