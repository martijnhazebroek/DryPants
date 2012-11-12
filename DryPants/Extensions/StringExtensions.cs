using System;
using System.Globalization;
using DryPants.Lib;
using JetBrains.Annotations;

namespace DryPants.Extensions
{
    public static class StringExtensions
    {
        public static string EachLine(this string source, Action<string> action)
        {
            return source.EachLine(Environment.NewLine, action);
        }

        private static string EachLine(this string source, string seperator, Action<string> action)
        {
            foreach (string value in source.Split(seperator.ToCharArray()))
                action(value);

            return source;
        }

        public static string FormatNamed(this string source, object propertySource)
        {
            return source.HenriFormat(propertySource);
        }

        [StringFormatMethod("source")]
        public static string FormatParams(this string source, params object[] args)
        {
            return source.FormatParams(CultureInfo.InvariantCulture, args);
        }

        private static string FormatParams(this string source, IFormatProvider provider, params object[] args)
        {
            return string.Format(provider, source, args);
        }
    }
}