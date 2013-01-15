using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using DryPants.Exceptions;

namespace DryPants.Resources
{
    [Serializable]
    public class DryAppSettingException : DryException
    {
        public DryAppSettingException(string message, object propertySource) 
            : base(message, propertySource) {}

        [ExcludeFromCodeCoverage]
        protected DryAppSettingException(SerializationInfo info, StreamingContext context)
            : base(info, context) {}
    }
}
