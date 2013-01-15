using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using DryPants.Extensions;

namespace DryPants.Exceptions
{
    [Serializable]
    public abstract class DryException : Exception
    {
        protected DryException() {}

        protected DryException(string message) : base(message) {}

        protected DryException(string message, object propertySource) : 
            base(message.FormatNamed(propertySource)) {}

        protected DryException(string message, object propertySource, Exception innerException)
            : base(message.FormatNamed(propertySource), innerException) {}

        protected DryException(string message, Exception innerException)
            : base(message, innerException) {}

        [ExcludeFromCodeCoverage]
        protected DryException(SerializationInfo info, StreamingContext context) 
            : base(info, context) {}
    }
}
