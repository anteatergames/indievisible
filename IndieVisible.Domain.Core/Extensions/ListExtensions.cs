using System.Collections.Generic;

namespace IndieVisible.Domain.Core.Extensions
{
    public static class ListExtensions
    {
        public static List<T> Safe<T>(this List<T> list)
        {
            return list ?? new List<T>();
        }
    }
}