using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SportClub.logic
{
    /// <summary>
    /// Defines the basic class for all exceptions used in MVC Basic Site solution.
    /// </summary>
    [Serializable]
    public class MvcBasicException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the MvcBasicException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public MvcBasicException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the MvcBasicException class with a specified error message 
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception. 
        /// If the innerException parameter is not a null reference, the current exception is raised 
        /// in a catch block that handles the inner exception.</param>	
        /// <remarks>
        /// An exception that is thrown as a direct result of a previous exception should include 
        /// a reference to the previous exception in the InnerException property. 
        /// The InnerException property returns the same value that is passed into the constructor, 
        /// or a null reference if the InnerException property does not supply the inner exception 
        /// value to the constructor.
        /// </remarks>			
        public MvcBasicException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the MvcBasicException class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected MvcBasicException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
