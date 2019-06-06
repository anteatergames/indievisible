using IndieVisible.Application.Interfaces;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
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
            OperationResultVo response;

            if (userId == Guid.Empty)
            {
                response = new OperationResultVo("You must be logged in to follow a game");
            }
            else
            {
                bool alreadyLiked = gameFollowDomainService.GetAll().Any(x => x.GameId == gameId && x.UserId == userId);

                if (alreadyLiked)
                {
                    response = new OperationResultVo(false);
                    response.Message = "Game already followed";
                }
                else
                {
                    GameFollow model = new GameFollow();

                    model.GameId = gameId;
                    model.UserId = userId;

                    this.gameFollowDomainService.Add(model);

                    unitOfWork.Commit();

                    int newCount = this.gameFollowDomainService.Count(x => x.GameId == gameId);

                    response = new OperationResultVo<int>(newCount);
                }
            }

            return response;
        }

        public OperationResultVo GameUnfollow(Guid userId, Guid gameId)
        {
            OperationResultVo response;

            if (userId == Guid.Empty)
            {
                response = new OperationResultVo("You must be logged in to unfollow a game");
            }
            else
            {

                GameFollow existingLike = this.gameFollowDomainService.GetAll().FirstOrDefault(x => x.GameId == gameId && x.UserId == userId);

                if (existingLike == null)
                {
                    response = new OperationResultVo(false);
                    response.Message = "You are not following this game.";
                }
                else
                {
                    OperationResultVo result = this.RemoveGameFollow(existingLike.Id); // TODO move to domain service

                    if (result.Success)
                    {
                        unitOfWork.Commit();
                    }

                    int newCount = this.gameFollowDomainService.Count(x => x.GameId == gameId);

                    response = new OperationResultVo<int>(newCount);
                }
            }

            return response;
        }

        private OperationResultVo RemoveGameFollow(Guid id)
        {
            OperationResultVo result;

            try
            {
                // validate before

                this.gameFollowDomainService.Remove(id);

                unitOfWork.Commit();

                result = new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }
        #endregion

        #region Profile Follow
        public OperationResultVo UserFollow(Guid userId, Guid followUserId)
        {
            OperationResultVo response;

            if (userId == Guid.Empty)
            {
                response = new OperationResultVo("You must be logged in to follow a user");
            }
            else
            {
                bool alreadyLiked = userFollowDomainService.GetAll().Any(x => x.UserId == userId && x.FollowUserId == followUserId);

                if (alreadyLiked)
                {
                    response = new OperationResultVo(false);
                    response.Message = "User already followed";
                }
                else
                {
                    UserFollow model = new UserFollow();

                    model.FollowUserId = followUserId;
                    model.UserId = userId;

                    this.userFollowDomainService.Add(model);

                    unitOfWork.Commit();

                    int newCount = this.userFollowDomainService.Count(x => x.FollowUserId == followUserId);

                    response = new OperationResultVo<int>(newCount);
                }
            }

            return response;
        }

        public OperationResultVo UserUnfollow(Guid userId, Guid followUserId)
        {
            OperationResultVo response;

            if (userId == Guid.Empty)
            {
                response = new OperationResultVo("You must be logged in to unfollow a user.");
            }
            else
            {

                UserFollow existingLike = this.userFollowDomainService.GetAll().FirstOrDefault(x => x.UserId == userId && x.FollowUserId == followUserId);

                if (existingLike == null)
                {
                    response = new OperationResultVo(false);
                    response.Message = "You are not following this user.";
                }
                else
                {
                    OperationResultVo result = this.RemoveProfileFollow(existingLike.Id); // TODO move to domain service

                    if (result.Success)
                    {
                        unitOfWork.Commit();
                    }

                    int newCount = this.userFollowDomainService.GetAll().Count(x => x.FollowUserId == followUserId);

                    response = new OperationResultVo<int>(newCount);
                }
            }

            return response;
        }

        private OperationResultVo RemoveProfileFollow(Guid id)
        {
            OperationResultVo result;

            try
            {
                this.userFollowDomainService.Remove(id);

                unitOfWork.Commit();

                result = new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }
        #endregion
    }
}
