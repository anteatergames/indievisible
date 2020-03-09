using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            IQueryable<JobPosition> all = repository.Get(x => x.Status == JobPositionStatus.OpenForApplication);

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

        public List<JobPositionApplicationVo> GetApplicationsByUserId(Guid userId)
        {
            IQueryable<JobPositionApplicationVo> all = repository.Get(x => x.Applicants.Any(y => y.UserId == userId)).Select(x => new JobPositionApplicationVo { JobPositionId = x.Id, WorkType = x.WorkType, Location = (x.Remote ? "remote" : x.Location), ApplicationDate = x.Applicants.First(y => y.UserId == userId).CreateDate });

            return all.ToList();
        }

        public void AddApplicant(Guid userId, Guid jobPositionId, string email, string coverLetter)
        {
            JobApplicant applicant = new JobApplicant
            {
                UserId = userId,
                Email = email,
                CoverLetter = coverLetter
            };

            Task<bool> task = repository.AddApplicant(jobPositionId, applicant);

            task.Wait();
        }

        public JobPosition GenerateNewJobPosition(Guid currentUserId, JobPositionOrigin origin)
        {
            JobPosition model = new JobPosition();

            model.Remote = true;
            model.Origin = origin;

            if (model.Origin == JobPositionOrigin.External)
            {
                model.Status = JobPositionStatus.OpenForApplication;
            }

            model.Benefits = Enum.GetValues(typeof(JobPositionBenefit)).Cast<JobPositionBenefit>().Where(x => x != JobPositionBenefit.NotInformed).Select(x => new JobPositionBenefitVo { Benefit = x, Available = false }).ToList();

            return model;
        }
    }
}
