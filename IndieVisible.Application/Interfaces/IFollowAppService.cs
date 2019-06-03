using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.UserLike;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.Interfaces
{
    public interface IFollowAppService
    {
        OperationResultVo GameFollow(Guid userId, Guid gameId);

        OperationResultVo GameUnfollow(Guid userId, Guid gameId);


        OperationResultVo UserFollow(Guid userId, Guid followUserId);

        OperationResultVo UserUnfollow(Guid userId, Guid followUserId);
    }
}
