using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Services
{
    public class JobPositionDomainService : BaseDomainMongoService<JobPosition, IJobPositionRepository>, IJobPositionDomainService
    {
        public JobPositionDomainService(IJobPositionRepository repository) : base(repository)
        {
        }

        public void AddApplicant(Guid userId, Guid jobPositionId, string coverLetter)
        {
            JobApplicant applicant = new JobApplicant
            {
                UserId = userId,
                CoverLetter = coverLetter
            };

            Task<bool> task = repository.AddApplicant(jobPositionId, applicant);

            task.Wait();
        }
    }
}
