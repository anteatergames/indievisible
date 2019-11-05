using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Services
{
    public class ProfileDomainService : BaseDomainMongoService<UserProfile, IUserProfileRepository>, IProfileDomainService
    {

        public ProfileDomainService(IUserProfileRepository repository) : base(repository)
        {
        }

        public void AddFollow(UserFollow model)
        {
            Task.Run(async () => await repository.AddFollow(model));
        }

        public bool CheckFollowing(Guid userId, Guid folloWedUserId)
        {
            var task = repository.GetFollows(x => x.UserId == userId && x.FollowUserId == folloWedUserId);

            task.Wait();

            var exists = task.Result.Any();

            return exists;
        }

        public int CountFollow(Expression<Func<UserFollow, bool>> where)
        {
            var task = repository.CountFollow(where);

            task.Wait();

            return task.Result;
        }

        public UserProfileEssentialVo GetBasicDataByUserId(Guid targetUserId)
        {
            var task = repository.GetBasicDataByUserId(targetUserId);

            task.Wait();

            return task.Result;
        }

        public IEnumerable<UserFollow> GetFollows(Expression<Func<UserFollow, bool>> where)
        {
            var task = Task.Run(async () => await repository.GetFollows(where));

            return task.Result;
        }

        public void RemoveFollow(UserFollow existingFollow)
        {
            Task.Run(async () => await repository.RemoveFollower(existingFollow.UserId, existingFollow.FollowUserId));
        }

        public void UpdateNameOnThePlatform(Guid userId, string newName)
        {
            //repositorySql.UpdateNameOnThePlatform(userId, newName);
        }
    }
}
