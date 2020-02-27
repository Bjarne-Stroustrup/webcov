using System;
using System.Collections.Generic;

namespace WebCov.Extensions
{
    public static class EnumerableExtensions
    {
        public static int IndexOfFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var index = 0;
            foreach (var value in source)
            {
                if (predicate(value))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }
    }
}