using IndieVisible.Domain.Models;
using System;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IProfileBaseAppService
    {
        void SetCache(Guid key, UserProfile value);
    }
}
