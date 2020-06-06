using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Interfaces.Services
{
    public interface IJobPositionDomainService : IDomainService<JobPosition>
    {
        void AddApplicant(Guid userId, Guid jobPositionId, string email, string coverLetter);

        IEnumerable<JobPosition> GetAllAvailable();

        JobPosition GenerateNewJobPosition(Guid currentUserId, JobPositionOrigin origin);

        Dictionary<JobPositionStatus, int> GetPositionsStats(Guid userId);

        List<JobPositionApplicationVo> GetApplicationsByUserId(Guid userId);
    }
}