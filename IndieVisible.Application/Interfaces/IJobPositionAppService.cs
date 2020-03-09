using IndieVisible.Application.ViewModels.Jobs;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface IJobPositionAppService : ICrudAppService<JobPositionViewModel>
    {
        OperationResultVo GetAllAvailable(Guid currentUserId);

        OperationResultVo Apply(Guid currentUserId, Guid jobPositionId, string email, string coverLetter);

        OperationResultVo GenerateNew(Guid currentUserId, JobPositionOrigin origin);

        OperationResultVo GetAllMine(Guid currentUserId);

        OperationResultVo ChangeStatus(Guid currentUserId, Guid jobPositionId, JobPositionStatus selectedStatus);

        OperationResultVo GetMyPositionsStats(Guid currentUserId);

        OperationResultVo RateApplicant(Guid currentUserId, Guid jobPositionId, Guid userId, decimal score);

        OperationResultVo GetMyApplications(Guid currentUserId);
    }
}