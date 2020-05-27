using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    /// <summary>
    /// This class contains the code for custom exception
    /// </summary>
    public class CustomException : Exception
    {
        //// Exception type variable
        ExceptionType type;
       
        /// <summary>
        /// Enum method to declared constant
        /// </summary>
        public enum ExceptionType
        {
            USERID_NOT_NULL
        }

        /// <summary>
        /// This method is created for exception method
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public CustomException(ExceptionType type, String message) : base(message)
        {
            this.type = type;
        }
    }
}
