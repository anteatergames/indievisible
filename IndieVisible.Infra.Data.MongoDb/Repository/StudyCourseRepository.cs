using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class StudyCourseRepository : BaseRepository<StudyCourse>, IStudyCourseRepository
    {
        public StudyCourseRepository(IMongoContext context) : base(context)
        {
        }

        public List<StudyCourseListItemVo> GetCourses()
        {
            IQueryable<StudyCourseListItemVo> obj = DbSet.AsQueryable().Select(x => new StudyCourseListItemVo
            {
                Id = x.Id,
                Name = x.Name,
                OpenForApplication = x.OpenForApplication,
                StudentCount = x.Members.Count()
            });

            return obj.ToList();
        }

        public List<StudyCourseListItemVo> GetCoursesByUserId(Guid userId)
        {
            IQueryable<StudyCourseListItemVo> obj = DbSet.AsQueryable().Where(x => x.UserId == userId).Select(x => new StudyCourseListItemVo
            {
                Id = x.Id,
                Name = x.Name,
                OpenForApplication = x.OpenForApplication,
                StudentCount = x.Members.Count()
            });

            return obj.ToList();
        }

        public IQueryable<StudyPlan> GetPlans(Guid courseId)
        {
            return DbSet.AsQueryable().Where(x => x.Id == courseId).SelectMany(x => x.Plans);
        }

        public async Task<bool> AddPlan(Guid courseId, StudyPlan plan)
        {
            plan.Id = Guid.NewGuid();

            FilterDefinition<StudyCourse> filter = Builders<StudyCourse>.Filter.Where(x => x.Id == courseId);
            UpdateDefinition<StudyCourse> add = Builders<StudyCourse>.Update.AddToSet(c => c.Plans, plan);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, add);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }

        public async Task<bool> UpdatePlan(Guid courseId, StudyPlan plan)
        {
            plan.LastUpdateDate = DateTime.Now;

            FilterDefinition<StudyCourse> filter = Builders<StudyCourse>.Filter.And(
                Builders<StudyCourse>.Filter.Eq(x => x.Id, courseId),
                Builders<StudyCourse>.Filter.ElemMatch(x => x.Plans, x => x.Id == plan.Id));

            UpdateDefinition<StudyCourse> update = Builders<StudyCourse>.Update
                .Set(c => c.Plans[-1].Name, plan.Name)
                .Set(c => c.Plans[-1].Description, plan.Description)
                .Set(c => c.Plans[-1].ScoreToPass, plan.ScoreToPass)
                .Set(c => c.Plans[-1].Order, plan.Order)
                .Set(c => c.Plans[-1].Activities, plan.Activities);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, update);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }

        public async Task<bool> RemovePlan(Guid courseId, Guid planId)
        {
            FilterDefinition<StudyCourse> filter = Builders<StudyCourse>.Filter.Where(x => x.Id == courseId);
            UpdateDefinition<StudyCourse> remove = Builders<StudyCourse>.Update.PullFilter(c => c.Plans, m => m.Id == planId);

            UpdateResult result = await DbSet.UpdateOneAsync(filter, remove);

            return result.IsAcknowledged && result.MatchedCount > 0;
        }
    }
}
