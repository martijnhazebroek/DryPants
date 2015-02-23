using System;
using System.Globalization;
using System.Text;

namespace DryPants.Extensions
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendIf(this StringBuilder builder, bool predicate, string value)
        {
            if(builder == null) throw new ArgumentNullException("builder");
            
            return predicate ? builder.Append(value) : builder;
        }

        public static StringBuilder AppendFormatIf(this StringBuilder builder, bool predicate, string format, params object[] args)
        {
            if (builder == null) throw new ArgumentNullException("builder");

            return predicate ? builder.AppendFormat(CultureInfo.InvariantCulture, format, args) : builder;
        }
    }
}