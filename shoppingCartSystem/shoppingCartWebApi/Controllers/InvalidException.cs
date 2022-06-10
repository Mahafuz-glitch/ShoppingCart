using System;
using System.Runtime.Serialization;

namespace shoppingCartWebApi.Controllers
{
    [Serializable]
    internal class InvalidException : Exception
    {
        public InvalidException()
        {
        }

        public InvalidException(string message) : base(message)
        {
        }

        public InvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}