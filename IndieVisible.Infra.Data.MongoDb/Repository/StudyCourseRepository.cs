using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Repository.Base;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Repository
{
    public class StudyCourseRepository : BaseRepository<StudyCourse>, IStudyCourseRepository
    {
        public StudyCourseRepository(IMongoContext context) : base(context)
        {
        }

        public List<StudyCourseListItemVo> GetCoursesByUserId(Guid userId)
        {
            var obj = DbSet.AsQueryable().Where(x => x.UserId == userId).Select(x => new StudyCourseListItemVo
            {
                Id = x.Id,
                Name = x.Name,
                OpenForApplication = x.OpenForApplication,
                StudentCount = x.Members.Count()
            });

            return obj.ToList();
        }
    }
}
