using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Artech.WcfServices.Service.Interface
{
    [DataContract(Namespace = "http://www.artech.com/")]
    public class CalculationError
    {
        public CalculationError(string operation, string message)
        {
            this.Operation = operation;
            this.Message = message;
        }
        [DataMember]
        public string Operation { get; set; }
        [DataMember]
        public string Message { get; set; }
    }

}
