using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.Interfaces
{
    public interface IUserConnectionAppService : ICrudAppService<UserConnectionViewModel>
    {
        OperationResultListVo<UserConnectionViewModel> GetByTargetUserId(Guid targetUserId);
        OperationResultVo Connect(Guid currentUserId, Guid userId);
        OperationResultVo Disconnect(Guid currentUserId, Guid userId);
        OperationResultVo Allow(Guid currentUserId, Guid userId);
        OperationResultVo Deny(Guid currentUserId, Guid userId);
    }
}
