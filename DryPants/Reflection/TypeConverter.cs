using DryPants.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DryPants.Reflection
{
    internal static class TypeConverter
    {
        #region Internal static

        internal static T ConvertToType<T>(string stringValue)
        {
            Type targetType = typeof (T);

            T convertedValue;
            if (TryConvertWithTypeConverter(stringValue, targetType, out convertedValue))
            {
                return convertedValue;
            }

            if (TryConvertWithStringConstructor(stringValue, targetType, out convertedValue))
            {
                return convertedValue;
            }

            object convertedValueList;
            if (TryConvertToStringList(stringValue, targetType, out convertedValueList))
            {
                return (T)convertedValueList;
            }

            throw new ConvertAppSettingToTypeException(targetType);
        }

        #endregion

        #region Private static

        private static bool TryConvertWithStringConstructor<T>(string stringValue, Type targetType, out T convertedValue)
        {
            convertedValue = default(T);

            if (!HasStringConstructor(targetType))
            {
                return false;
            }

            if (typeof (FileSystemInfo).IsAssignableFrom(typeof (T)))
            {
                stringValue = Environment.ExpandEnvironmentVariables(stringValue);
            }

            convertedValue = (T)CreateInstance(targetType, stringValue);

            return true;
        }

        private static bool TryConvertToStringList(string stringValue, Type targetType, out object convertedValue)
        {
            convertedValue = null;

            Type listType = typeof (IList<string>);
            if (!listType.IsAssignableFrom(targetType))
                return false;

            convertedValue = new List<string>();
            foreach (string value in Regex.Replace(stringValue, @"\s", "").Split(','))
            {
                ((IList) convertedValue).Add(value);
            }

            return true;
        }

        private static bool TryConvertWithTypeConverter<T>(string stringValue, Type targetType, out T convertedValue)
        {
            convertedValue = default(T);

            System.ComponentModel.TypeConverter converter = TypeDescriptor.GetConverter(targetType);
            if (converter.CanConvertFrom(typeof (string)))
            {
                convertedValue = (T)converter.ConvertFromInvariantString(stringValue);
                return true;
            }

            return false;
        }

        private static object CreateInstance(Type type, params object[] args)
        {
            try
            {
                return Activator.CreateInstance(type, args);
            }
            catch (TypeLoadException)
            {
                throw new ConvertAppSettingToTypeException(type);
            }
        }

        private static bool HasStringConstructor(Type source)
        {
            Type stringType = typeof (string);

            return (from constructorInfo in source.GetConstructors()
                    let parameters = constructorInfo.GetParameters()
                    where parameters.Count() == 1 &&
                          parameters.First().ParameterType == stringType
                    select true).Any();
        }

        #endregion
    }
}
