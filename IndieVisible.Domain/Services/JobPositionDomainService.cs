using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace IndieVisible.Domain.Services
{
    public class JobPositionDomainService : BaseDomainMongoService<JobPosition, IJobPositionRepository>, IJobPositionDomainService
    {
        public JobPositionDomainService(IJobPositionRepository repository) : base(repository)
        {
        }

        public override Guid Add(JobPosition model)
        {
            if (model.Status == 0)
            {
                model.Status = JobPositionStatus.Draft;
            }

            return base.Add(model);
        }

        public IEnumerable<JobPosition> GetAllAvailable()
        {
            var all = repository.Get(x => x.Status == JobPositionStatus.OpenForApplication);

            return all;
        }

        public Dictionary<JobPositionStatus, int> GetPositionsStats(Guid userId)
        {
            var all = from x in repository.Get(x => x.UserId == userId)
                      group x by x.Status into grouped
                      select new
                      {
                          Status = grouped.Key,
                          Count = grouped.Count()
                      };

            return all.ToDictionary(x => x.Status, y => y.Count);
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

        public JobPosition GenerateNewJobPosition(Guid currentUserId, JobPositionOrigin origin)
        {
            var model = new JobPosition();

            model.Remote = true;
            model.Origin = origin;

            if (model.Origin == JobPositionOrigin.External)
            {
                model.Status = JobPositionStatus.OpenForApplication;
            }

            return model;
        }
    }
}
