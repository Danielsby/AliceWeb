using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace DatabaseTables.Helpers
{
    /// <summary>
    /// Custom exceptions
    /// Differentiate between handled and unhandled exceptions. 
    /// </summary>
    public class AppException : Exception
    {
        public AppException() : base() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        { 
        }
    }
}
