using System;
using System.Runtime.Serialization;

namespace JwtAuthentication.Service.Exceptions
{
    /// <summary>
    ///     Represents an exception that is thrown when the credentials are invalid.
    /// </summary>
    [Serializable]
    public class InvalidCredentialsException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidCredentialsException" /> class.
        /// </summary>
        public InvalidCredentialsException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidCredentialsException" /> class with a message.
        /// </summary>
        /// <param name="message">The message</param>
        public InvalidCredentialsException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidCredentialsException" /> class with a message and an inner
        ///     exception.
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="inner">The inner exception</param>
        public InvalidCredentialsException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="InvalidCredentialsException" /> class with a serialization info and s
        ///     streaming context.
        /// </summary>
        /// <param name="info">The serialization info</param>
        /// <param name="context">The streaming context</param>
        protected InvalidCredentialsException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}