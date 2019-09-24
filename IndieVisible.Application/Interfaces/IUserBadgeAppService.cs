using IndieVisible.Application.ViewModels.Gamification;
using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface IUserBadgeAppService : ICrudAppService<UserBadgeViewModel>
    {
        OperationResultListVo<UserBadgeViewModel> GetByUser(Guid userId);
    }
}
