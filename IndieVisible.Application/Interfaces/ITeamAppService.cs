using System;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.Team;
using IndieVisible.Domain.ValueObjects;

namespace IndieVisible.Application.Interfaces
{
    public interface ITeamAppService : ICrudAppService<TeamViewModel>
    {
        OperationResultVo GenerateNewTeam(Guid currentUserId);

        OperationResultVo AcceptInvite(Guid teamId, Guid currentUserId, string quote);

        OperationResultVo RejectInvite(Guid teamId, Guid currentUserId);

        OperationResultVo GetByUserId(Guid userId);
        OperationResultVo RemoveMember(Guid currentUserId, Guid teamId, Guid userId);
    }
}
