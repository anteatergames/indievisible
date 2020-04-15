using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IProfileBaseAppService
    {
        void SetProfileCache(Guid userId, UserProfile value);

        OperationResultVo GetCountries(Guid currentUserId);
    }
}