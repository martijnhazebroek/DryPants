using System;
using DryPants.Mocking;

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
            return SystemTime.Now().Subtract(source);
        }
        
        public static DateTime FromNow(this TimeSpan source)
        {
            return SystemTime.Now().Add(source);
        }
    }
}
