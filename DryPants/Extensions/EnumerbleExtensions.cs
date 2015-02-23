using System;
using System.Collections.Generic;
using System.Linq;

namespace DryPants.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Fast way to check if an IEnumerable{T} has a given number of items.
        /// Faster than using enumerable.Count().
        /// </summary>
        /// <typeparam name="T">The key of the enumerable.</typeparam>
        /// <param name="source">The source object.</param>
        /// <param name="count">The number of items to check for.</param>
        /// <returns>true if it has number items; otherwise false.</returns>
        public static bool CountAtLeast<T>(this IEnumerable<T> source, int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            
            return count == 0 ? !source.Any() : source.Skip(count - 1).Any();
        }
    }
}
