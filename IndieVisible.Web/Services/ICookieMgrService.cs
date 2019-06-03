using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Web.Services
{
    public interface ICookieMgrService
    {
        string Get(string key);

        void Set(string key, string value, int? expireTime);
    }
}
