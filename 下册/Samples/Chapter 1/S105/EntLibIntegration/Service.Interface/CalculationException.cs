using System;
namespace Artech.EntLibIntegration.Service.Interface
{
    [global::System.Serializable]
    public class CalculationException : Exception
    {
        public CalculationException() { }
        public CalculationException(string message) : base(message) { }
        public CalculationException(string message, Exception inner) : base(message, inner) { }
        protected CalculationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}