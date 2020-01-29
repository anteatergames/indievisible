using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        Task<IQueryable<UserFollow>> GetFollows(Guid userId, Guid followerId);

        Task<int> CountFollowers(Guid userId);

        Task<bool> AddFollow(Guid followerUserId, Guid userId);

        Task<bool> RemoveFollower(Guid userId, Guid followUserId);

        Task<UserProfileEssentialVo> GetBasicDataByUserId(Guid targetUserId);

        Task<IEnumerable<Guid>> GetAllUserIds();
    }
}