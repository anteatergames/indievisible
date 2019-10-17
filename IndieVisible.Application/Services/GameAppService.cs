using AutoMapper;
using AutoMapper.QueryableExtensions;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Base;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly IGameRepository repository;
        private readonly IGameLikeRepository gameLikeRepository;
        private readonly IGamificationDomainService gamificationDomainService;
        private readonly IGameFollowDomainService gameFollowDomainService;

        public GameAppService(IMapper mapper, IUnitOfWork unitOfWork, IGameRepository repository, IGameLikeRepository gameLikeRepository
            , IGamificationDomainService gamificationDomainService
            , IGameFollowDomainService gameFollowDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.gameLikeRepository = gameLikeRepository;
            this.gamificationDomainService = gamificationDomainService;
            this.gameFollowDomainService = gameFollowDomainService;
        }

        #region ICrudAppService
        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = repository.GetAll().Count();

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
                IQueryable<Game> allModels = repository.GetAll();

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
                Game model = repository.GetById(id);

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
            var pointsEarned = 0;

            try
            {
                Game model;

                viewModel.ExternalLinks.RemoveAll(x => String.IsNullOrWhiteSpace(x.Value));

                Game existing = repository.GetById(viewModel.Id);
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
                    repository.Add(model);
                    viewModel.Id = model.Id;

                    pointsEarned += gamificationDomainService.ProcessAction(viewModel.UserId, PlatformAction.GameAdd);
                }
                else
                {
                    repository.Update(model);
                }

                unitOfWork.Commit();

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
                // validate before

                repository.Remove(id);

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
            IQueryable<Game> allModels = repository.GetAll();

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
            IQueryable<Game> allModels = repository.GetAll().Where(x => x.UserId == userId);

            List<SelectListItemVo> vms = allModels.ProjectTo<SelectListItemVo>(mapper.ConfigurationProvider).ToList();

            return vms;
        }
    }
}
