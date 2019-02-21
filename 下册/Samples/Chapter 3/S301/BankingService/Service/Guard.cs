using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artech.TransactionalService.Service
{
    public static class Guard
    {        
        public static void ArgumentNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void ArgumentNotNullOrEmpty(string argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName);
            }
            if (argumentValue.Length == 0)
            {
                throw new ArgumentException(string.Format("The argument \"{0}\" is empty!",argumentName));
            }
        }

        public static void ArgumenGreaterThanZero(double argumentValue, string argumentName)
        {
            if (argumentValue <= 0)
            {
                throw new ArgumentException(string.Format("The argument \"{0}\" is not greater than zero!", argumentName));
            }
        }
    }

 

}
