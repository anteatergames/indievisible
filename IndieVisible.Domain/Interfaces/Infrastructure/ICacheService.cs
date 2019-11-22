using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Interfaces.Infrastructure
{
    public interface ICacheService
    {
        string Get(string key);
        void Set(string key, string value);
        string GetOrCreate(string key, string value);
    }
}
