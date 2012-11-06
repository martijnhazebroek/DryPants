using System;

namespace DryPants.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal RoundDown(this decimal source, int decimalPlaces)
        {
            var factor = (int) Math.Pow(10, decimalPlaces);

            return source >= 0
                       ? Math.Floor(source*factor)/factor
                       : Math.Ceiling(source*factor)/factor;
        } 
        
        public static decimal RoundUp(this decimal source, int decimalPlaces)
        {
            var factor = (int) Math.Pow(10, decimalPlaces);

            return source >= 0
                       ? Math.Ceiling(source*factor)/factor
                       : Math.Floor(source*factor)/factor;
        }
    }
}
