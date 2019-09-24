using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface IGameFollowAppService : ICrudAppService<GameFollowViewModel>
    {
        OperationResultListVo<GameFollowViewModel> GetByGameId(Guid gameId);
    }
}
