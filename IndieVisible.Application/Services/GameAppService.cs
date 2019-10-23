using AutoMapper;
using AutoMapper.QueryableExtensions;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class GameAppService : BaseAppService, IGameAppService
    {
        private readonly IMapper mapper;
        private readonly IndieVisible.Infra.Data.MongoDb.Interfaces.IUnitOfWork _uow;
        private readonly IGameLikeRepository gameLikeRepository;
        private readonly IGamificationDomainService gamificationDomainService;
        private readonly IGameFollowDomainService gameFollowDomainService;

        private readonly Infra.Data.MongoDb.Interfaces.Repository.IGameRepository gameRepositoryMongo;

        public GameAppService(IMapper mapper
            , IndieVisible.Infra.Data.MongoDb.Interfaces.IUnitOfWork _uow
            , Infra.Data.MongoDb.Interfaces.Repository.IGameRepository gameRepositoryMongo
            , IGameLikeRepository gameLikeRepository
            , IGamificationDomainService gamificationDomainService
            , IGameFollowDomainService gameFollowDomainService)
        {
            this.mapper = mapper;
            this._uow = _uow;
            this.gameRepositoryMongo = gameRepositoryMongo;
            this.gameLikeRepository = gameLikeRepository;
            this.gamificationDomainService = gamificationDomainService;
            this.gameFollowDomainService = gameFollowDomainService;
        }

        #region ICrudAppService
        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = gameRepositoryMongo.Count().Result;

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
                IEnumerable<Game> allModels = gameRepositoryMongo.GetAll().Result;

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
                Game model = gameRepositoryMongo.GetById(id).Result;

                GameViewModel vm = mapper.Map<GameViewModel>(model);

                vm.LikeCount = gameLikeRepository.Count(x => x.GameId == vm.Id);
                vm.FollowerCount = gameFollowDomainService.Count(x => x.GameId == vm.Id);

                vm.CurrentUserLiked = gameLikeRepository.GetAll().Any(x => x.GameId == vm.Id && x.UserId == currentUserId);
                vm.CurrentUserFollowing = gameFollowDomainService.GetAll().Any(x => x.GameId == vm.Id && x.UserId == currentUserId);

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
                Game model;

                viewModel.ExternalLinks.RemoveAll(x => String.IsNullOrWhiteSpace(x.Value));

                Game existing = gameRepositoryMongo.GetById(viewModel.Id).Result;
                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<Game>(viewModel);
                }

                if (viewModel.Id == Guid.Empty)
                {
                    gameRepositoryMongo.Add(model);

                    pointsEarned += gamificationDomainService.ProcessAction(viewModel.UserId, PlatformAction.GameAdd);
                }
                else
                {
                    gameRepositoryMongo.Update(model);
                }

                _uow.Commit();
                viewModel.Id = model.Id;


                return new OperationResultVo<Guid>(model.Id, pointsEarned);
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
                gameRepositoryMongo.Remove(id);
                _uow.Commit();

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
            IQueryable<Game> allModels = gameRepositoryMongo.Get();

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
            }

            return vms;
        }

        public IEnumerable<SelectListItemVo> GetByUser(Guid userId)
        {
            IEnumerable<Game> allModels = gameRepositoryMongo.GetByUserId(userId).Result;

            List<SelectListItemVo> vms = mapper.Map<IEnumerable<Game>, IEnumerable<SelectListItemVo>>(allModels).ToList();

            return vms;
        }
    }
}
