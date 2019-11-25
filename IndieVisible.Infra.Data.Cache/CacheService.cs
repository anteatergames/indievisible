using IndieVisible.Domain.Interfaces.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Infra.Data.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public string Get(string key)
        {
            var obj = (string)memoryCache.Get(key);

            return obj;
        }

        public T Get<T>(string key)
        {
            var obj = (T)memoryCache.Get(key);

            return obj;
        }

        public T Get<TKey, T>(TKey key)
        {
            var obj = (T)memoryCache.Get(key);

            return obj;
        }

        public string GetOrCreate(string key, string value)
        {
            var obj = memoryCache.GetOrCreate(key, entry => value);

            return obj;
        }

        public T GetOrCreate<T>(string key, T value)
        {
            var obj = memoryCache.GetOrCreate(key, entry => value);

            return obj;
        }

        public void Set(string key, string value)
        {
            memoryCache.Set(key, value);
        }

        public void Set<T>(string key, T value)
        {
            memoryCache.Set(key, value);
        }

        public void Set<Tkey, T>(Tkey key, T value)
        {
            memoryCache.Set(key, value);
        }
    }
}
