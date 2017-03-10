using System;
using System.Collections.Generic;
using System.Linq;

namespace LoggingDemo.Util
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> DefaultIfEmpty<T>(this IEnumerable<T> collection, Func<T> defaultDelegate)
        {
            if (collection.Any())
                return collection;

            return
                collection
                .DefaultIfEmpty(defaultDelegate());
        }
    }
}