using System;
using System.Linq;

namespace DryPants.Extensions
{
    public static class EnumExtensions
    {
        public static bool IsOneOf(this Enum source, params Enum[] enumValues)
        {
            return enumValues.Contains(source);
        }
    }
}