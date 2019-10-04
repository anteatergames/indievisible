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

        public OperationResultVo<int> Count()
        {
            OperationResultVo<int> result;

            try
            {
                int count = repository.GetAll().Count();

                result = new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<int>(ex.Message);
            }

            return result;
        }


        public OperationResultListVo<GameViewModel> GetAll(Guid currentUserId)
        {
            OperationResultListVo<GameViewModel> result;

            try
            {
                IQueryable<Game> allModels = repository.GetAll();

                IEnumerable<GameViewModel> vms = mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(allModels);

                result = new OperationResultListVo<GameViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<GameViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<GameViewModel> GetById(Guid currentUserId, Guid id)
        {
            OperationResultVo<GameViewModel> result;

            try
            {
                Game model = repository.GetById(id);

                GameViewModel vm = mapper.Map<GameViewModel>(model);

                SetWebsiteUrl(vm);

                vm.LikeCount = gameLikeRepository.Count(x => x.GameId == vm.Id);
                vm.FollowerCount = gameFollowDomainService.Count(x => x.GameId == vm.Id);

                vm.CurrentUserLiked = gameLikeRepository.GetAll().Any(x => x.GameId == vm.Id && x.UserId == currentUserId);
                vm.CurrentUserFollowing = this.gameFollowDomainService.GetAll().Any(x => x.GameId == vm.Id && x.UserId == currentUserId);

                result = new OperationResultVo<GameViewModel>(vm);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<GameViewModel>(ex.Message);
            }

            return result;
        }

        private static void SetWebsiteUrl(GameViewModel vm)
        {
            if (!string.IsNullOrWhiteSpace(vm.WebsiteUrl))
            {
                vm.WebsiteUrl = vm.WebsiteUrl.ToLower();

                if (!vm.WebsiteUrl.StartsWith("http:") && !vm.WebsiteUrl.StartsWith("https:"))
                {
                    vm.WebsiteUrl = "http://" + vm.WebsiteUrl;
                }
            }
        }

        public OperationResultVo Remove(Guid id)
        {
            OperationResultVo result;

            try
            {
                // validate before

                repository.Remove(id);

                unitOfWork.Commit();

                result = new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }

        public OperationResultVo<Guid> Save(GameViewModel viewModel)
        {
            OperationResultVo<Guid> result;

            try
            {
                Game model;

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

                    this.gamificationDomainService.ProcessAction(viewModel.UserId, PlatformAction.GameAdd);
                }
                else
                {
                    repository.Update(model);
                }

                unitOfWork.Commit();

                result = new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<Guid>(ex.Message);
            }

            return result;
        }

        public IEnumerable<GameListItemViewModel> GetLatest(Guid currentUserId, int count, Guid userId, GameGenre genre)
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
