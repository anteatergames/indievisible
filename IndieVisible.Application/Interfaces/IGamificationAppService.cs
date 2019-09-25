using IndieVisible.Application.ViewModels.Gamification;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface IGamificationAppService
    {
        OperationResultListVo<RankingViewModel> GetAll();

        OperationResultVo FillProfileGamificationDetails(Guid currentUserId, ref ProfileViewModel vm);

        OperationResultListVo<GamificationLevelViewModel> GetAllLevels();
    }
}
