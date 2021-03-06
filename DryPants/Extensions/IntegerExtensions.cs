﻿using System;
using System.Collections.Generic;
using System.Linq;
using DryPants.Core;
using DryPants.Exceptions;

namespace DryPants.Extensions
{
    public static class IntegerExtensions
    {
        public static TimeSpan Days(this int source)
        {
            return new TimeSpan(source, 0, 0, 0);
        }

        public static TimeSpan Hours(this int source)
        {
            return new TimeSpan(0, source, 0, 0);
        }

        public static TimeSpan Minutes(this int source)
        {
            return new TimeSpan(0, 0, source, 0);
        }

        public static TimeSpan Seconds(this int source)
        {
            return new TimeSpan(0, 0, 0, source);
        }

        public static bool IsEven(this int source)
        {
            return source % 2 == 0;
        }

        public static bool IsOdd(this int source)
        {
            return !source.IsEven();
        }

        public static int Times(this int source, Action<int> action)
        {
            if (source < 0) return 0;

            0.UpTo(source - 1, action);

            return source;
        }

        public static int[] UpTo(this int source, int limit)
        {
            return limit < source ? new[] { source } : source.InternalUpTo(limit).ToArray();
        }

        public static int UpTo(this int source, int limit, Action<int> action)
        {
            Throw.IfArgumentNull(() => action);

            foreach (int i in source.UpTo(limit))
                action(i);

            return source;
        }

        internal static IEnumerable<int> InternalUpTo(this int source, int limit)
        {
            for (int i = source; i <= limit; i++)
                yield return i;
        }

        public static int[] DownTo(this int source, int limit)
        {
            if (limit > source) return new[] { source };

            return source.PrivateDownTo(limit).ToArray();
        }

        public static int DownTo(this int source, int limit, Action<int> action)
        {
            Throw.IfArgumentNull(() => action);

            foreach (int i in source.DownTo(limit))
                action(i);

            return source;
        }

        private static IEnumerable<int> PrivateDownTo(this int source, int limit)
        {
            for (int i = source; i >= limit; i--)
                yield return i;
        }

        public static Percentage Percent(this int source)
        {
            return new Percentage(source);
        }

        public static Percentage IsPercentageOf(this int source, decimal value)
        {
            return Percentage.IsPercentageOf(source, value);
        }
    }
}