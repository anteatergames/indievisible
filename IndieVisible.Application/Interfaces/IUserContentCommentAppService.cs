using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.UserLike;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.Interfaces
{
    public interface IUserContentCommentAppService : ICrudAppService<UserContentCommentViewModel>
    {
        OperationResultVo Comment(UserContentCommentViewModel viewModel);
    }
}
