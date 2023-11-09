using System;
namespace JoeBank.Exceptions
{
    /// <summary>
    /// A generic handler for all exceptions in Customer Class
    /// Parent of all exceptions
    /// Extends Application Exception
    /// </summary>
    public class CustomerException:ApplicationException
    {      
        /// <summary>
        /// Constructor that initializes the message 
        /// </summary>
        /// <param name="message">exception message</param>
        public CustomerException(string message):base(message)
        {  //carry  base(message) forward to base constructor ApplicationException acceps message param

        }
        // exception thrown bal for example is known as outer exception
        /// <summary>
        /// Constructor that inits exception message and inner exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public CustomerException(string message, Exception innerException) : base(message, innerException)
        {  //carry  base(message) forward to base constructor ApplicationException acceps message param

        }
    }
}
