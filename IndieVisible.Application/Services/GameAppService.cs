using AutoMapper;
using AutoMapper.QueryableExtensions;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.Interfaces.Infrastructure;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class GameAppService : ProfileBaseAppService, IGameAppService
    {
        private readonly IGamificationDomainService gamificationDomainService;
        private readonly ITeamDomainService teamDomainService;

        private readonly IGameDomainService gameDomainService;

        public GameAppService(IMapper mapper
            , IUnitOfWork unitOfWork
            , ICacheService cacheService
            , IProfileDomainService profileDomainService
            , ITeamDomainService teamDomainService
            , IGameDomainService gameDomainService
            , IGamificationDomainService gamificationDomainService) : base(mapper, unitOfWork, cacheService, profileDomainService)
        {
            this.gameDomainService = gameDomainService;
            this.teamDomainService = teamDomainService;
            this.gamificationDomainService = gamificationDomainService;
        }

        #region ICrudAppService

        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = gameDomainService.Count();

                return new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<int>(ex.Message);
            }
        }

        public OperationResultListVo<GameViewModel> GetAll(Guid currentUserId)
        {
            try
            {
                IEnumerable<Game> allModels = gameDomainService.GetAll();

                IEnumerable<GameViewModel> vms = mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(allModels);

                return new OperationResultListVo<GameViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<GameViewModel>(ex.Message);
            }
        }

        public OperationResultVo<GameViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                Game model = gameDomainService.GetById(id);

                GameViewModel vm = mapper.Map<GameViewModel>(model);

                vm.LikeCount = model.Likes.SafeCount(x => x.GameId == vm.Id);
                vm.FollowerCount = model.Followers.SafeCount(x => x.GameId == vm.Id);

                vm.CurrentUserLiked = model.Likes.SafeAny(x => x.GameId == vm.Id && x.UserId == currentUserId);
                vm.CurrentUserFollowing = model.Followers.SafeAny(x => x.GameId == vm.Id && x.UserId == currentUserId);

                UserProfile authorProfile = GetCachedProfileByUserId(vm.UserId);
                vm.AuthorName = authorProfile.Name;

                return new OperationResultVo<GameViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<GameViewModel>(ex.Message);
            }
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, GameViewModel viewModel)
        {
            int pointsEarned = 0;

            try
            {
                Game game;
                Team newTeam = null;
                bool createTeam = viewModel.TeamId == Guid.Empty;

                if (createTeam)
                {
                    newTeam = teamDomainService.GenerateNewTeam(currentUserId);
                    newTeam.Name = String.Format("Team {0}", viewModel.Title);
                    teamDomainService.Add(newTeam);
                }

                viewModel.ExternalLinks.RemoveAll(x => String.IsNullOrWhiteSpace(x.Value));

                Game existing = gameDomainService.GetById(viewModel.Id);
                if (existing != null)
                {
                    game = mapper.Map(viewModel, existing);
                }
                else
                {
                    game = mapper.Map<Game>(viewModel);
                }

                if (viewModel.Id == Guid.Empty)
                {
                    gameDomainService.Add(game);

                    pointsEarned += gamificationDomainService.ProcessAction(viewModel.UserId, PlatformAction.GameAdd);
                }
                else
                {
                    gameDomainService.Update(game);
                }

                unitOfWork.Commit();
                viewModel.Id = game.Id;

                if (createTeam && newTeam != null)
                {
                    game.TeamId = newTeam.Id;
                    gameDomainService.Update(game);
                    unitOfWork.Commit();
                }

                return new OperationResultVo<Guid>(game.Id, pointsEarned);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            try
            {
                gameDomainService.Remove(id);
                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        #endregion ICrudAppService

        public IEnumerable<GameListItemViewModel> GetLatest(Guid currentUserId, int count, Guid userId, Guid? teamId, GameGenre genre)
        {
            IQueryable<Game> allModels = gameDomainService.Get(genre, userId, teamId);

            IOrderedQueryable<Game> ordered = allModels.OrderByDescending(x => x.CreateDate);

            IQueryable<Game> taken = ordered.Take(count);

            List<GameListItemViewModel> vms = taken.ProjectTo<GameListItemViewModel>(mapper.ConfigurationProvider).ToList();

            foreach (GameListItemViewModel item in vms)
            {
                item.ThumbnailUrl = string.IsNullOrWhiteSpace(item.ThumbnailUrl) || Constants.DefaultGameThumbnail.NoExtension().Contains(item.ThumbnailUrl.NoExtension()) ? Constants.DefaultGameThumbnail : UrlFormatter.Image(item.UserId, BlobType.GameThumbnail, item.ThumbnailUrl, 278);
                item.DeveloperImageUrl = UrlFormatter.ProfileImage(item.UserId, 40);

                UserProfile authorProfile = GetCachedProfileByUserId(item.UserId);
                item.DeveloperName = authorProfile.Name;
            }

            return vms;
        }

        public IEnumerable<SelectListItemVo> GetByUser(Guid userId)
        {
            IEnumerable<Game> allModels = gameDomainService.GetByUserId(userId);

            List<SelectListItemVo> vms = mapper.Map<IEnumerable<Game>, IEnumerable<SelectListItemVo>>(allModels).ToList();

            return vms;
        }

        public OperationResultVo GameFollow(Guid currentUserId, Guid gameId)
        {
            try
            {
                if (currentUserId == Guid.Empty)
                {
                    return new OperationResultVo("You must be logged in to follow a game");
                }

                gameDomainService.Follow(currentUserId, gameId);

                unitOfWork.Commit();

                int newCount = gameDomainService.CountFollowers(gameId);

                return new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GameUnfollow(Guid currentUserId, Guid gameId)
        {
            try
            {
                if (currentUserId == Guid.Empty)
                {
                    return new OperationResultVo("You must be logged in to unfollow a game");
                }

                gameDomainService.Unfollow(currentUserId, gameId);

                unitOfWork.Commit();

                int newCount = gameDomainService.CountFollowers(gameId);

                return new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GameLike(Guid currentUserId, Guid gameId)
        {
            try
            {
                gameDomainService.Like(currentUserId, gameId);

                unitOfWork.Commit();

                int newCount = gameDomainService.CountLikes(gameId);

                return new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GameUnlike(Guid currentUserId, Guid gameId)
        {
            try
            {
                gameDomainService.Unlike(currentUserId, gameId);

                unitOfWork.Commit();

                int newCount = gameDomainService.CountLikes(gameId);

                return new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }
    }
}