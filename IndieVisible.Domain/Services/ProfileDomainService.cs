using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Services
{
    public class ProfileDomainService : BaseDomainService<UserProfile, IProfileRepository>, IProfileDomainService
    {
        private readonly IUserFollowRepository userFollowRepository;
        private readonly IUserProfileRepository userProfileRepository;

        public ProfileDomainService(IProfileRepository repository
            , IUserFollowRepository userFollowRepository
            , IUserProfileRepository userProfileRepository) : base(repository)
        {
            this.userFollowRepository = userFollowRepository;
            this.userProfileRepository = userProfileRepository;
        }

        public int CountFollow(Expression<Func<UserFollow, bool>> where)
        {
            int followCount = userFollowRepository.Count(where);

            return followCount;
        }

        public IEnumerable<UserFollow> GetFollows(Expression<Func<UserFollow, bool>> where)
        {
            IQueryable<UserFollow> follows = userFollowRepository.Get(where);

            return follows;
        }

        public void UpdateNameOnThePlatform(Guid userId, string newName)
        {
            repository.UpdateNameOnThePlatform(userId, newName);
        }

        public override IEnumerable<UserProfile> GetByUserId(Guid userId)
        {
            var existing = userProfileRepository.GetByUserId(userId).Result;

            if (existing == null || !existing.Any())
            {
                var entityFromSql = repository.GetByUserId(userId);

                if (entityFromSql != null && entityFromSql.Any())
                {
                    var entity = entityFromSql.FirstOrDefault();
                    if (entity != null)
                    {
                        userProfileRepository.Add(entity);
                    }

                    existing = entityFromSql;
                }
            }

            return existing;
        }

        public override Guid Update(UserProfile model)
        {
            userProfileRepository.Update(model);

            return base.Update(model);
        }
    }
}
