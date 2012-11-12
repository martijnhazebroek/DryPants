using System;

namespace DryPants.Core
{
    internal static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
        internal static readonly Func<DateTime> Today = () => Now().Date;
    }
}