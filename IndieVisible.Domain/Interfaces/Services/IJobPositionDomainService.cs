using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface IJobPositionDomainService : IDomainService<JobPosition>
    {
        void AddApplicant(Guid userId, Guid jobPositionId, string coverLetter);
        IEnumerable<JobPosition> GetAllAvailable();
        JobPosition GenerateNewJobPosition(Guid currentUserId);
        Dictionary<JobPositionStatus, int> GetPositionsStats(Guid userId);
    }
}