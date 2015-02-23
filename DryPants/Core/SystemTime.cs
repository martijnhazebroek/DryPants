using System;

namespace DryPants.Core
{
    internal static class SystemTime
    {
        public static Func<DateTime> Now = Reset();
    
        public static Func<DateTime> Reset()
        {
            return Now = ()=> DateTime.Now;
        }
    }
}