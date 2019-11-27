using System.Collections.Generic;

namespace IndieVisible.Domain.Core.Extensions
{
    public static class ICollectionExtensions
    {
        public static ICollection<T> Safe<T>(this ICollection<T> list)
        {
            return list ?? new List<T>();
        }
    }
}