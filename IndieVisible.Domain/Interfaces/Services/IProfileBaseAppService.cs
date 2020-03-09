using IndieVisible.Domain.Models;
using System;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IProfileBaseAppService
    {
        void SetProfileCache(Guid userId, UserProfile value);
    }
}