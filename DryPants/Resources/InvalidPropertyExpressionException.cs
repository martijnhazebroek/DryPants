using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using DryPants.Exceptions;

namespace DryPants.Resources
{
    [Serializable]
    public class InvalidPropertyExpressionException : DryException
    {
        public InvalidPropertyExpressionException() : base(Errors.ExpressionNotPropertyOrArgumentName) {}

        [ExcludeFromCodeCoverage]
        protected InvalidPropertyExpressionException(SerializationInfo info, StreamingContext context)
            : base(info, context) {}
    }
}
