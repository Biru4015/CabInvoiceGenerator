using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class CustomException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            USERID_NOT_NULL
        }

        public CustomException(ExceptionType type, String message) : base(message)
        {
            this.type = type;
        }
    }
}
