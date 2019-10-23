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
    public class ProfileDomainService : BaseDomainMongoService<UserProfile, IUserProfileRepository>, IProfileDomainService
    {
        private readonly IUserFollowRepository userFollowRepository;

        public ProfileDomainService(IUserProfileRepository repository
            , IUserFollowRepository userFollowRepository) : base(repository)
        {
            this.userFollowRepository = userFollowRepository;
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
            //repositorySql.UpdateNameOnThePlatform(userId, newName);
        }
    }
}
