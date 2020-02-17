using IndieVisible.Application.ViewModels;
using IndieVisible.Application.ViewModels.Brainstorm;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface IBrainstormAppService : ICrudAppService<BrainstormIdeaViewModel>
    {
        OperationResultVo Vote(Guid userId, Guid ideaId, VoteValue vote);

        OperationResultVo Comment(CommentViewModel vm);

        OperationResultVo<BrainstormSessionViewModel> GetSession(Guid sessionId);

        OperationResultVo<BrainstormSessionViewModel> GetSession(Guid userId, BrainstormSessionType type);

        OperationResultListVo<BrainstormSessionViewModel> GetSessions(Guid userId);

        OperationResultVo<Guid> SaveSession(BrainstormSessionViewModel vm);

        OperationResultListVo<BrainstormIdeaViewModel> GetAllBySessionId(Guid userId, Guid sessionId);

        OperationResultVo<BrainstormSessionViewModel> GetMainSession();

        OperationResultVo ChangeStatus(Guid currentUserId, Guid ideaId, BrainstormIdeaStatus selectedStatus);
    }
}