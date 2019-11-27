using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface IPollAppService
    {
        OperationResultVo PollVote(Guid currentUserId, Guid pollOptionId);
    }
}