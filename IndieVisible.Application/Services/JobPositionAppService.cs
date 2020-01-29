using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Domain.Interfaces;
using IndieVisible.Domain.Interfaces.Infrastructure;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndieVisible.Application.Services
{
    public class JobPositionAppService : ProfileBaseAppService, IJobPositionAppService
    {
        private readonly IJobPositionDomainService jobPositionDomainService;

        public JobPositionAppService(IMapper mapper
            , IUnitOfWork unitOfWork
            , ICacheService cacheService
            , IProfileDomainService profileDomainService
            , IJobPositionDomainService jobPositionDomainService) : base(mapper, unitOfWork, cacheService, profileDomainService)
        {
            this.jobPositionDomainService = jobPositionDomainService;
        }

        public OperationResultVo Apply(Guid currentUserId, Guid jobPositionId, string coverLetter)
        {
            try
            {
                int pointsEarned = 0;

                var jobPosition = jobPositionDomainService.GetById(jobPositionId);

                if (jobPosition == null)
                {
                    return new OperationResultVo("Unable to identify the job position you are applying for.");
                }

                var alreadyApplyed = jobPosition.Applicants.Any(x => x.UserId == currentUserId);
                if (alreadyApplyed)
                {
                    return new OperationResultVo("You already applyed for this job position.");
                }

                jobPositionDomainService.AddApplicant(currentUserId, jobPositionId, coverLetter);

                unitOfWork.Commit();

                return new OperationResultVo(pointsEarned);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }
    }
}
