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

        public string GetOrCreate(string key, string value)
        {
            var obj = memoryCache.GetOrCreate(key, entry => value);

            return obj;
        }

        public void Set(string key, string value)
        {
            memoryCache.Set(key, value);
        }
    }
}
