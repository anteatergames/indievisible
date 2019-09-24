using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface IUserFollowAppService : ICrudAppService<UserFollowViewModel>
    {
        OperationResultListVo<UserFollowViewModel> GetByUserId(Guid userId);
        OperationResultListVo<UserFollowViewModel> GetByFollowedId(Guid followUserId);
    }
}
