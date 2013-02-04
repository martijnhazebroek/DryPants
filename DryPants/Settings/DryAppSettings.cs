using DryPants.Reflection;
using DryPants.Resources;
using System;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq.Expressions;

namespace DryPants.Settings
{
    public abstract class DryAppSettings
    {
        private readonly NameValueCollection _appSettings;

        private readonly Lazy<ConcurrentDictionary<string, object>> _convertedValueCache =
            new Lazy<ConcurrentDictionary<string, object>>(() => new ConcurrentDictionary<string, object>());

        protected DryAppSettings() : this(ConfigurationManager.AppSettings) {}

        protected DryAppSettings(NameValueCollection appSettings)
        {
            _appSettings = appSettings;
        }

        private ConcurrentDictionary<string, object> Cache
        {
            get { return _convertedValueCache.Value; }
        }

        protected T GetAppSettingFor<T>(Expression<Func<T>> appSettingKeyExpression)
        {
            string key = PropertyName.For(appSettingKeyExpression);

            if (_appSettings[key] == null)
                throw new AppSettingDoesNotExistException(key);

            if (Cache.ContainsKey(key))
            {
                return (T) Cache[key];
            }

            string stringValue = _appSettings[key];
            var convertedValue = TypeConvertAppSetting<T>(stringValue);
            Cache.TryAdd(key, convertedValue);

            return convertedValue;
        }

        protected virtual T TypeConvertAppSetting<T>(string appSettingValue)
        {
            return TypeConverter.ConvertToType<T>(appSettingValue);
        }
    }
}
