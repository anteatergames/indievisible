using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Domain.Interfaces.Services
{
    public interface IProfileBaseAppService
    {
        void SetProfileCache(Guid userId, UserProfile value);

        OperationResultVo GetCountries(Guid currentUserId);
    }
}