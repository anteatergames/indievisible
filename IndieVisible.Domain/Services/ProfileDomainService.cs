using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IndieVisible.Domain.Services
{
    public class ProfileDomainService : BaseDomainService<UserProfile, IProfileRepository>, IProfileDomainService
    {
        private readonly IUserFollowRepository userFollowRepository;
        private readonly ITeamMemberRepository teamMemberRepository;

        public ProfileDomainService(IProfileRepository repository
            , IUserFollowRepository userFollowRepository
            , ITeamMemberRepository teamMemberRepository) : base(repository)
        {
            this.userFollowRepository = userFollowRepository;
            this.teamMemberRepository = teamMemberRepository;
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

        public void UpdateNameOnThePlatform(Guid userId, string newName)
        {
            var teamMemberships = teamMemberRepository.Get(x => x.UserId == userId);

            foreach (var item in teamMemberships)
            {
                item.Name = newName;
            }
        }
    }
}
