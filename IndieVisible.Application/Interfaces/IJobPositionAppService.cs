using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface IJobPositionAppService
    {
        OperationResultVo Apply(Guid currentUserId, Guid jobPositionId, string coverLetter);
    }
}