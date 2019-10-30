using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Domain.ValueObjects;

namespace IndieVisible.Application.Interfaces
{
    public interface IUserContentCommentAppService : ICrudAppService<UserContentCommentViewModel>
    {
       // OperationResultVo Comment(UserContentCommentViewModel viewModel);
    }
}
