using IndieVisible.Application.ViewModels.Brainstorm;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface IBrainstormAppService : ICrudAppService<BrainstormIdeaViewModel>
    {
        OperationResultListVo<BrainstormIdeaViewModel> GetAll(Guid userId);

        OperationResultVo<BrainstormIdeaViewModel> GetById(Guid userId, Guid id);

        OperationResultVo Vote(Guid userId, Guid ideaId, VoteValue vote);

        OperationResultVo Comment(UserContentCommentViewModel vm);

        OperationResultVo<BrainstormSessionViewModel> GetSession(Guid userId, BrainstormSessionType type);

        OperationResultListVo<BrainstormSessionViewModel> GetSessions(Guid userId);

        OperationResultVo<Guid> SaveSession(BrainstormSessionViewModel vm);
        OperationResultListVo<BrainstormIdeaViewModel> GetAllBySessionId(Guid userId, Guid sessionId);
        OperationResultVo<BrainstormSessionViewModel> GetMainSession();
        OperationResultVo<BrainstormSessionViewModel> GetSession(Guid sessionId);
    }
}
