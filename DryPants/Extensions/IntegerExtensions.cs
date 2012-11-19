using System;
using System.Collections.Generic;
using System.Linq;

namespace DryPants.Extensions
{
    public static class IntegerExtensions
    {
        #region To: TimeSpan

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

        #endregion

        #region To: Boolean

        public static bool IsEven(this int source)
        {
            return source%2 == 0;
        }

        public static bool IsOdd(this int source)
        {
            return !source.IsEven();
        }

        #endregion

        #region To: Integer

        public static int Times(this int source, Action<int> action)
        {
            if (source < 0) return 0;

            0.UpTo(source - 1, action);

            return source;
        }

        #endregion

        #region To: Integer ([])

        public static int[] UpTo(this int source, int limit)
        {
            if (limit < source) return new[] {source};

            return source.InternalUpTo(limit).ToArray();
        }

        public static int UpTo(this int source, int limit, Action<int> action)
        {
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
            if (limit > source) return new[] {source};

            return source.PrivateDownTo(limit).ToArray();
        }

        public static int DownTo(this int source, int limit, Action<int> action)
        {
            foreach (int i in source.DownTo(limit))
                action(i);

            return source;
        }

        private static IEnumerable<int> PrivateDownTo(this int source, int limit)
        {
            for (int i = source; i >= limit; i--)
                yield return i;
        }

        #endregion
    }
}