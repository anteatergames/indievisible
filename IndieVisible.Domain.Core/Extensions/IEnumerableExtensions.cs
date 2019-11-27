using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Domain.Core.Extensions
{
    public static class IEnumerableExtensions
    {
        public static int SafeCount<T>(this IEnumerable<T> list)
        {
            return list == null ? 0 : list.Count();
        }

        public static int SafeCount<T>(this IEnumerable<T> list, Func<T, bool> where)
        {
            return list == null ? 0 : list.Count(where);
        }

        public static bool SafeAny<T>(this IEnumerable<T> list, Func<T, bool> where)
        {
            return list != null && list.Any(where);
        }
    }
}