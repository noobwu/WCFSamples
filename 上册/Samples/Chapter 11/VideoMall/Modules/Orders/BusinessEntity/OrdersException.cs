using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artech.VideoMall.Orders.BusinessEntity
{
    [Serializable]
    public class OrdersException : Exception
    {
        public OrdersException() { }
        public OrdersException(string message) : base(message) { }
        public OrdersException(string message, Exception inner) : base(message, inner) { }
        protected OrdersException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
