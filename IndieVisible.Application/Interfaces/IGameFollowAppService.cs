using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.Interfaces
{
    public interface IGameFollowAppService : ICrudAppService<GameFollowViewModel>
    {
        OperationResultListVo<GameFollowViewModel> GetByGameId(Guid gameId);
    }
}
