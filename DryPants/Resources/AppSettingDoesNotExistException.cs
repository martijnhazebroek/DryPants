using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace DryPants.Resources
{
    [Serializable]
    public class AppSettingDoesNotExistException : DryAppSettingException
    {
        public AppSettingDoesNotExistException(string key) :
            base(Errors.AppSettingDoesNotExist, new {Key = key}) {}

        [ExcludeFromCodeCoverage]
        protected AppSettingDoesNotExistException(SerializationInfo info, StreamingContext context)
            : base(info, context) {}
    }
}
