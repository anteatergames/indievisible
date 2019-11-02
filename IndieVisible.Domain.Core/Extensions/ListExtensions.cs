using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndieVisible.Domain.Core.Extensions
{
    public static class ListExtensions
    {
        public static List<T> Safe<T>(this List<T> list)
        {
            return list ??  new List<T>();
        }
    }
}
