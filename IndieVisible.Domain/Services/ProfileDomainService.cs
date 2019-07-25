using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace IndieVisible.Domain.Services
{
    public class ProfileDomainService : BaseDomainService<UserProfile, IProfileRepository>, IProfileDomainService
    {
        private readonly IUserFollowRepository userFollowRepository;

        public ProfileDomainService(IProfileRepository repository
            , IUserFollowRepository userFollowRepository) : base(repository)
        {
            this.userFollowRepository = userFollowRepository;
        }

        public int CountFollow(Expression<Func<UserFollow, bool>> where)
        {
            var followCount = userFollowRepository.Count(where);

            return followCount;
        }

        public IEnumerable<UserFollow> GetFollows(Expression<Func<UserFollow, bool>> where)
        {
            var follows = userFollowRepository.Get(where);

            return follows;
        }
    }
}
