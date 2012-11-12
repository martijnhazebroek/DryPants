﻿using System;
using System.Globalization;
using DryPants.Core;

namespace DryPants.Extensions
{
    public static class DateTimeExtensions
    {
        public static int ToAge(this DateTime birthday)
        {
            DateTime now = SystemTime.Now();

            int age = now.Year - birthday.Year;
            age = birthday > now.AddYears(-age) ? age - 1 : age;
            age = Math.Max(0, age);

            return age;
        }

        public static int GetDaysInMonth(this DateTime source)
        {
            return CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(source.Year, source.Month);
        }

        public static int GetDaysInYear(this DateTime source)
        {
            return CultureInfo.CurrentCulture.Calendar.GetDaysInYear(source.Year);
        }

        public static bool IsLeapYear(this DateTime source)
        {
            return CultureInfo.CurrentCulture.Calendar.IsLeapYear(source.Year);
        }

        public static bool IsWorkday(this DateTime source)
        {
            return !source.DayOfWeek.IsOneOf(DayOfWeek.Saturday, DayOfWeek.Sunday);
        }

        public static DateTime FirstDayOfMonth(this DateTime source)
        {
            return new DateTime(source.Year,
                                source.Month,
                                1 /* day */,
                                source.Hour,
                                source.Minute,
                                source.Second,
                                source.Millisecond);
        }

        public static DateTime LastDayOfMonth(this DateTime source)
        {
            return new DateTime(source.Year,
                                source.Month,
                                source.GetDaysInMonth(),
                                source.Hour,
                                source.Minute,
                                source.Second,
                                source.Millisecond);
        }

        public static DateTime FirstDayOfWeek(this DateTime source)
        {
            DateTime day = source;
            do
            {
                day = day.AddDays(-1);
            } while (day.DayOfWeek != CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

            return day;
        }
    }
}