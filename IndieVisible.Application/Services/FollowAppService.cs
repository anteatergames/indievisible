﻿using IndieVisible.Application.Interfaces;
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
        public OperationResultVo GameFollow(Guid currentUserId, Guid gameId)
        {
            if (currentUserId == Guid.Empty)
            {
                return new OperationResultVo("You must be logged in to follow a game");
            }
            else
            {
                bool alreadyLiked = gameFollowDomainService.GetAll().Any(x => x.GameId == gameId && x.UserId == currentUserId);

                if (alreadyLiked)
                {
                    return new OperationResultVo(false, "Game already followed");
                }
                else
                {
                    GameFollow model = new GameFollow();

                    model.GameId = gameId;
                    model.UserId = currentUserId;

                    gameFollowDomainService.Add(model);

                    unitOfWork.Commit();

                    int newCount = gameFollowDomainService.Count(x => x.GameId == gameId);

                    return new OperationResultVo<int>(newCount);
                }
            }
        }

        public OperationResultVo GameUnfollow(Guid currentUserId, Guid gameId)
        {
            if (currentUserId == Guid.Empty)
            {
                return new OperationResultVo("You must be logged in to unfollow a game");
            }
            else
            {
                GameFollow existingLike = gameFollowDomainService.GetAll().FirstOrDefault(x => x.GameId == gameId && x.UserId == currentUserId);

                if (existingLike == null)
                {
                    return new OperationResultVo(false, "You are not following this game.");
                }
                else
                {

                    gameFollowDomainService.Remove(existingLike.Id);

                    unitOfWork.Commit();

                    int newCount = gameFollowDomainService.Count(x => x.GameId == gameId);

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

            Domain.Core.Interfaces.ISpecification<UserFollow> spec = new IdsNotEmptySpecification()
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
                userFollowDomainService.Add(model);

                unitOfWork.Commit();

                int newCount = userFollowDomainService.Count(x => x.FollowUserId == followUserId);

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
                UserFollow existingFollow = userFollowDomainService.GetAll().FirstOrDefault(x => x.UserId == currentUserId && x.FollowUserId == followUserId);

                if (existingFollow == null)
                {
                    return new OperationResultVo(false, "You are not following this user.");
                }
                else
                {
                    userFollowDomainService.Remove(existingFollow.Id);

                    unitOfWork.Commit();

                    int newCount = userFollowDomainService.GetAll().Count(x => x.FollowUserId == followUserId);

                    return new OperationResultVo<int>(newCount);
                }
            }
        }
        #endregion
    }
}
