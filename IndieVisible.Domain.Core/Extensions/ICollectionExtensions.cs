using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndieVisible.Domain.Core.Extensions
{
    public static class ICollectionExtensions
    {
        public static ICollection<T> SafeList<T>(this ICollection<T> list)
        {
            return list ??  new List<T>();
        }
    }
}
