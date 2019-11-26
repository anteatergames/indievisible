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
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class GameAppService : ProfileBaseAppService, IGameAppService
    {
        private readonly IGamificationDomainService gamificationDomainService;
        private readonly ITeamDomainService teamDomainService;

        private readonly IGameRepository gameRepository;

        public GameAppService(IMapper mapper
            , IUnitOfWork unitOfWork
            , ICacheService cacheService
            , IProfileDomainService profileDomainService
            , ITeamDomainService teamDomainService
            , IGameRepository gameRepository
            , IGamificationDomainService gamificationDomainService) :base(mapper, unitOfWork, cacheService, profileDomainService)
        {
            this.gameRepository = gameRepository;
            this.teamDomainService = teamDomainService;
            this.gamificationDomainService = gamificationDomainService;
        }

        #region ICrudAppService
        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = gameRepository.Count().Result;

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
                IEnumerable<Game> allModels = gameRepository.GetAll().Result;

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
                Game model = gameRepository.GetById(id).Result;

                GameViewModel vm = mapper.Map<GameViewModel>(model);

                vm.LikeCount = model.Likes.SafeCount(x => x.GameId == vm.Id);
                vm.FollowerCount = model.Followers.SafeCount(x => x.GameId == vm.Id);

                vm.CurrentUserLiked = model.Likes.SafeAny(x => x.GameId == vm.Id && x.UserId == currentUserId);
                vm.CurrentUserFollowing = model.Followers.SafeAny(x => x.GameId == vm.Id && x.UserId == currentUserId);

                var authorProfile = GetCachedProfileByUserId(vm.UserId);
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
                var createTeam = viewModel.TeamId == Guid.Empty;

                if (createTeam)
                {
                    newTeam = teamDomainService.GenerateNewTeam(currentUserId);
                    newTeam.Name = String.Format("Team {0}", viewModel.Title);
                    teamDomainService.Add(newTeam);
                }

                viewModel.ExternalLinks.RemoveAll(x => String.IsNullOrWhiteSpace(x.Value));

                Game existing = gameRepository.GetById(viewModel.Id).Result;
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
                    gameRepository.Add(game);

                    pointsEarned += gamificationDomainService.ProcessAction(viewModel.UserId, PlatformAction.GameAdd);
                }
                else
                {
                    gameRepository.Update(game);
                }

                unitOfWork.Commit();
                viewModel.Id = game.Id;

                if (createTeam && newTeam != null)
                {
                    game.TeamId = newTeam.Id;
                    gameRepository.Update(game);
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
                gameRepository.Remove(id);
                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }
        #endregion

        public IEnumerable<GameListItemViewModel> GetLatest(Guid currentUserId, int count, Guid userId, Guid? teamId, GameGenre genre)
        {
            IQueryable<Game> allModels = gameRepository.Get();

            if (genre != 0)
            {
                allModels = allModels.Where(x => x.Genre == genre);
            }

            if (userId != Guid.Empty)
            {
                allModels = allModels.Where(x => x.UserId == userId);
            }

            if (teamId.HasValue)
            {
                allModels = allModels.Where(x => x.TeamId == teamId);
            }

            IOrderedQueryable<Game> ordered = allModels.OrderByDescending(x => x.CreateDate);

            IQueryable<Game> taken = ordered.Take(count);

            List<GameListItemViewModel> vms = taken.ProjectTo<GameListItemViewModel>(mapper.ConfigurationProvider).ToList();

            foreach (GameListItemViewModel item in vms)
            {
                item.ThumbnailUrl = string.IsNullOrWhiteSpace(item.ThumbnailUrl) || Constants.DefaultGameThumbnail.Contains(item.ThumbnailUrl) ? Constants.DefaultGameThumbnail : UrlFormatter.Image(item.UserId, BlobType.GameThumbnail, item.ThumbnailUrl);
                item.DeveloperImageUrl = UrlFormatter.ProfileImage(item.UserId);

                var authorProfile = GetCachedProfileByUserId(item.UserId);
                item.DeveloperName = authorProfile.Name;
            }

            return vms;
        }

        public IEnumerable<SelectListItemVo> GetByUser(Guid userId)
        {
            IEnumerable<Game> allModels = gameRepository.GetByUserId(userId).Result;

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

                System.Threading.Tasks.Task<bool> task = gameRepository.Follow(currentUserId, gameId);

                task.Wait();

                unitOfWork.Commit();

                System.Threading.Tasks.Task<int> newCountTask = gameRepository.CountFollowers(gameId);

                newCountTask.Wait();

                return new OperationResultVo<int>(newCountTask.Result);
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

                System.Threading.Tasks.Task<bool> task = gameRepository.Unfollow(currentUserId, gameId);

                task.Wait();

                unitOfWork.Commit();

                System.Threading.Tasks.Task<int> newCountTask = gameRepository.CountFollowers(gameId);

                newCountTask.Wait();

                return new OperationResultVo<int>(newCountTask.Result);
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
                System.Threading.Tasks.Task<bool> task = gameRepository.Like(currentUserId, gameId);

                task.Wait();

                unitOfWork.Commit();

                System.Threading.Tasks.Task<int> newCountTask = gameRepository.CountLikes(gameId);

                newCountTask.Wait();

                return new OperationResultVo<int>(newCountTask.Result);
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
                System.Threading.Tasks.Task<bool> task = gameRepository.Unlike(currentUserId, gameId);

                task.Wait();

                unitOfWork.Commit();

                System.Threading.Tasks.Task<int> newCountTask = gameRepository.CountLikes(gameId);

                newCountTask.Wait();

                return new OperationResultVo<int>(newCountTask.Result);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }
    }
}
