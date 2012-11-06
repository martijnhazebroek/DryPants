using System;
using System.Linq;

namespace DryPants.Extensions
{
    public static class DateTimeExtensions
    {
        public static int GetDaysInMonth(this DateTime source)
        {
            return DateTime.DaysInMonth(source.Year, source.Month);
        }

        public static int GetDaysInYear(this DateTime source)
        {
            return 1.UpTo(12)
                    .Select(month => DateTime.DaysInMonth(source.Year, month))
                    .Sum();
        }
    }
}
