using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace IndieVisible.Domain.Core.Extensions
{
    public static class ListExtensions
    {
        public static List<T> Safe<T>(this List<T> list)
        {
            return list ?? new List<T>();
        }
        public static void Shuffle<T>(this IList<T> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}