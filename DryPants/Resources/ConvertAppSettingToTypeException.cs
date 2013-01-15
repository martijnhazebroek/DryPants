using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using DryPants.Exceptions;

namespace DryPants.Resources
{
    [Serializable]
    public class ConvertAppSettingToTypeException : DryAppSettingException
    {
        public ConvertAppSettingToTypeException(Type type) :
            base(Errors.UnableToCreateInstanceOfTypeForAppSetting, CreatePropertySourceParams(type)) {}

        [ExcludeFromCodeCoverage]
        protected ConvertAppSettingToTypeException(SerializationInfo info, StreamingContext context)
            : base(info, context) {}

        private static object CreatePropertySourceParams(Type type)
        {
            Throw.IfArgumentNull(() => type);

            return new {Name = type.FullName};
        }
    }
}
