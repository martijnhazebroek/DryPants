﻿using System;
using DryPants.Core;

namespace DryPants.Extensions
{
    public static class TimeSpanExtensions
    {
        public static DateTime After(this TimeSpan source, DateTime dateTime)
        {
            return dateTime.Add(source);
        }

        public static DateTime Before(this TimeSpan source, DateTime dateTime)
        {
            return dateTime.Subtract(source);
        }

        public static DateTime Ago(this TimeSpan source)
        {
            return Ago(source, SystemTime.Now());
        }

        public static DateTime Ago(this TimeSpan source, DateTime now)
        {
            return now.Subtract(source);
        }

        public static DateTime FromNow(this TimeSpan source)
        {
            return FromNow(source, SystemTime.Now());
        }

        internal static DateTime FromNow(this TimeSpan source, DateTime now)
        {
            return now.Add(source);
        }
    }
}