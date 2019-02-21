using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel;

namespace Artech.WcfServices.Service
{
    public class MessengerService : IMessenger
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}
