using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.Gamification;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IndieVisible.Application.Interfaces
{
    public interface IUserBadgeAppService : ICrudAppService<UserBadgeViewModel>
    {
        OperationResultListVo<UserBadgeViewModel> GetByUser(Guid userId);
    }
}
