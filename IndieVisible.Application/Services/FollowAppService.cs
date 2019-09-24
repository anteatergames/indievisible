using IndieVisible.Application.Interfaces;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.Specifications.Follow;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class FollowAppService : BaseAppService, IFollowAppService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGameFollowDomainService gameFollowDomainService;
        private readonly IUserFollowDomainService userFollowDomainService;

        public FollowAppService(IUnitOfWork unitOfWork
            , IGameFollowDomainService gameFollowDomainService
            , IUserFollowDomainService userFollowDomainService)
        {
            this.unitOfWork = unitOfWork;
            this.gameFollowDomainService = gameFollowDomainService;
            this.userFollowDomainService = userFollowDomainService;
        }

        #region Game Follow
        public OperationResultVo GameFollow(Guid userId, Guid gameId)
        {
            if (userId == Guid.Empty)
            {
                return new OperationResultVo("You must be logged in to follow a game");
            }
            else
            {
                bool alreadyLiked = gameFollowDomainService.GetAll().Any(x => x.GameId == gameId && x.UserId == userId);

                if (alreadyLiked)
                {
                    return new OperationResultVo(false, "Game already followed");
                }
                else
                {
                    GameFollow model = new GameFollow();

                    model.GameId = gameId;
                    model.UserId = userId;

                    this.gameFollowDomainService.Add(model);

                    unitOfWork.Commit();

                    int newCount = this.gameFollowDomainService.Count(x => x.GameId == gameId);

                    return new OperationResultVo<int>(newCount);
                }
            }
        }

        public OperationResultVo GameUnfollow(Guid userId, Guid gameId)
        {
            if (userId == Guid.Empty)
            {
                return new OperationResultVo("You must be logged in to unfollow a game");
            }
            else
            {
                GameFollow existingLike = this.gameFollowDomainService.GetAll().FirstOrDefault(x => x.GameId == gameId && x.UserId == userId);

                if (existingLike == null)
                {
                    return new OperationResultVo(false, "You are not following this game.");
                }
                else
                {

                    this.gameFollowDomainService.Remove(existingLike.Id);

                    unitOfWork.Commit();

                    int newCount = this.gameFollowDomainService.Count(x => x.GameId == gameId);

                    return new OperationResultVo<int>(newCount);
                }
            }
        }
        #endregion

        #region Profile Follow
        public OperationResultVo UserFollow(Guid currentUserId, Guid followUserId)
        {
            UserFollow model = new UserFollow();
            model.FollowUserId = followUserId;
            model.UserId = currentUserId;

            var spec = new IdsNotEmptySpecification()
                .And(new UserNotTheSameSpecification(currentUserId));

            if (!spec.IsSatisfiedBy(model))
            {
                return new OperationResultVo(false, spec.ErrorMessage);
            }

            bool alreadyFollowing = userFollowDomainService.GetAll().Any(x => x.UserId == currentUserId && x.FollowUserId == followUserId);

            if (alreadyFollowing)
            {
                return new OperationResultVo(false, "User already followed");
            }
            else
            {
                this.userFollowDomainService.Add(model);

                unitOfWork.Commit();

                int newCount = this.userFollowDomainService.Count(x => x.FollowUserId == followUserId);

                return new OperationResultVo<int>(newCount);

            }
        }

        public OperationResultVo UserUnfollow(Guid currentUserId, Guid followUserId)
        {
            if (currentUserId == Guid.Empty)
            {
                return new OperationResultVo("You must be logged in to unfollow a user.");
            }
            else
            {
                UserFollow existingFollow = this.userFollowDomainService.GetAll().FirstOrDefault(x => x.UserId == currentUserId && x.FollowUserId == followUserId);

                if (existingFollow == null)
                {
                    return new OperationResultVo(false, "You are not following this user.");
                }
                else
                {
                    this.userFollowDomainService.Remove(existingFollow.Id);

                    unitOfWork.Commit();

                    int newCount = this.userFollowDomainService.GetAll().Count(x => x.FollowUserId == followUserId);

                    return new OperationResultVo<int>(newCount);
                }
            }
        }
        #endregion
    }
}
