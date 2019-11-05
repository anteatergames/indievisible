using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IndieVisible.Infra.Data.MongoDb.Interfaces.Repository
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        Task<IQueryable<UserFollow>> GetFollows(Expression<Func<UserFollow, bool>> where);

        Task<int> CountFollow(Expression<Func<UserFollow, bool>> where);
        Task<bool> AddFollow(UserFollow model);
        Task<bool> RemoveFollower(Guid userId, Guid followUserId);
        Task<UserProfileEssentialVo> GetBasicDataByUserId(Guid targetUserId);
    }
}
