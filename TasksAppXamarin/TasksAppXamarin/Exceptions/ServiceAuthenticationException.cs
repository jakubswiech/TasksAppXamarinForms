using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TasksAppXamarin.Exceptions
{
    public class ServiceAuthenticationException : Exception
    {
        public ServiceAuthenticationException()
        {
        }

        protected ServiceAuthenticationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ServiceAuthenticationException(string message) : base(message)
        {
        }

        public ServiceAuthenticationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
