using AutoMapper;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UserProfile = IndieVisible.Domain.Models.UserProfile;

namespace IndieVisible.Application.Services
{
    public class ProfileAppService : BaseAppService, IProfileAppService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IProfileRepository repository;
        private readonly IGameRepository gameRepository;
        private readonly IUserContentRepository userContentRepository;
        private readonly IUserContentCommentRepository userContentCommentRepository;
        private readonly IBrainstormCommentRepository brainstormCommentRepository;
        private readonly IGamificationDomainService gamificationDomainService;
        private readonly IUserFollowDomainService userFollowDomainService;
        private readonly IUserConnectionDomainService userConnectionDomainService;

        public ProfileAppService(IMapper mapper, IUnitOfWork unitOfWork, IProfileRepository repository, IGameRepository gameRepository, IUserContentRepository userContentRepository
            , IUserContentCommentRepository userContentCommentRepository
            , IBrainstormCommentRepository brainstormCommentRepositor
            , IGamificationDomainService gamificationDomainService
            , IUserFollowDomainService userFollowDomainService
            , IUserConnectionDomainService userConnectionDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.gameRepository = gameRepository;
            this.userContentRepository = userContentRepository;
            this.userContentCommentRepository = userContentCommentRepository;
            this.brainstormCommentRepository = brainstormCommentRepositor;
            this.gamificationDomainService = gamificationDomainService;
            this.userFollowDomainService = userFollowDomainService;
            this.userConnectionDomainService = userConnectionDomainService;
        }

        #region ICrudAppService Implementation
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

        public OperationResultListVo<ProfileViewModel> GetAll()
        {
            OperationResultListVo<ProfileViewModel> result;

            try
            {
                IQueryable<UserProfile> allModels = repository.GetAll();

                IEnumerable<ProfileViewModel> vms = mapper.Map<IEnumerable<UserProfile>, IEnumerable<ProfileViewModel>>(allModels);

                result = new OperationResultListVo<ProfileViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<ProfileViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<ProfileViewModel> GetById(Guid id)
        {
            OperationResultVo<ProfileViewModel> result;

            try
            {
                UserProfile model = repository.GetById(id);

                ProfileViewModel vm = mapper.Map<ProfileViewModel>(model);

                result = new OperationResultVo<ProfileViewModel>(vm);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<ProfileViewModel>(ex.Message);
            }

            return result;
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

        public OperationResultVo<Guid> Save(ProfileViewModel viewModel)
        {
            OperationResultVo<Guid> result;

            try
            {
                UserProfile model;

                viewModel.GameJoltUrl = viewModel.GameJoltUrl?.TrimStart('@');

                UserProfile existing = repository.GetById(viewModel.Id);
                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<UserProfile>(viewModel);
                }

                if (model.Type == 0)
                {
                    model.Type = ProfileType.Personal;
                }

                if (viewModel.Id == Guid.Empty)
                {
                    repository.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    repository.Update(model);
                }

                IQueryable<Game> games = gameRepository.GetAll().Where(x => x.UserId == viewModel.UserId);

                foreach (Game g in games)
                {
                    g.DeveloperName = viewModel.Name;
                }

                IQueryable<UserContent> posts = userContentRepository.GetAll().Where(x => x.UserId == viewModel.UserId);

                foreach (UserContent p in posts)
                {
                    p.AuthorName = viewModel.Name;
                }

                IQueryable<UserContentComment> comments = userContentCommentRepository.GetAll().Where(x => x.UserId == viewModel.UserId);

                foreach (UserContentComment c in comments)
                {
                    c.AuthorName = viewModel.Name;
                }

                IQueryable<BrainstormComment> brainstormComments = brainstormCommentRepository.GetAll().Where(x => x.UserId == viewModel.UserId);

                foreach (BrainstormComment bc in brainstormComments)
                {
                    bc.AuthorName = viewModel.Name;
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
        #endregion

        #region IProfileAppService Implementation
        public ProfileViewModel GetByUserId(Guid userId, ProfileType type)
        {
            return GetByUserId(userId, userId, type);
        }
        public ProfileViewModel GetByUserId(Guid currentUserId, Guid userId, ProfileType type)
        {
            ProfileViewModel vm = new ProfileViewModel();

            IEnumerable<UserProfile> profiles = repository.GetByUserId(userId);
            UserProfile model = profiles.FirstOrDefault(x => x.Type == type);

            if (profiles.Any() && model != null)
            {
                vm = mapper.Map(model, vm);
            }
            else
            {
                return null;
            }

            vm.CoverImageUrl = UrlFormatter.ProfileCoverImage(vm.UserId, vm.Id);

            vm.ProfileImageUrl = UrlFormatter.ProfileImage(vm.UserId);

            FormatExternalNetworkUrls(vm);

            vm.Counters.Games = gameRepository.Count(x => x.UserId == vm.UserId);
            vm.Counters.Posts = userContentRepository.Count(x => x.UserId == vm.UserId);
            vm.Counters.Comments = userContentCommentRepository.Count(x => x.UserId == vm.UserId);

            Gamification gamification = this.gamificationDomainService.GetByUserId(userId);

            unitOfWork.Commit();


            GamificationLevel currentLevel = this.gamificationDomainService.GetLevel(gamification.CurrentLevelNumber);

            vm.IndieXp.LevelName = currentLevel.Name;
            vm.IndieXp.Level = gamification.CurrentLevelNumber;
            vm.IndieXp.LevelXp = gamification.XpCurrentLevel;
            vm.IndieXp.NextLevelXp = gamification.XpToNextLevel + gamification.XpCurrentLevel;

            vm.Counters.Followers = this.userFollowDomainService.Count(x => x.FollowUserId == vm.UserId);
            vm.Counters.Following = this.userFollowDomainService.Count(x => x.UserId == currentUserId);
            int connectionsToUser = this.userConnectionDomainService.Count(x => x.TargetUserId == vm.UserId && x.ApprovalDate.HasValue);
            int connectionsFromUser = this.userConnectionDomainService.Count(x => x.UserId == vm.UserId && x.ApprovalDate.HasValue);

            vm.Counters.Connections = connectionsToUser + connectionsFromUser;

            vm.CurrentUserFollowing = this.userFollowDomainService.Get(x => x.UserId == currentUserId && x.FollowUserId == vm.UserId).Any();
            vm.ConnectionControl.CurrentUserConnected = this.userConnectionDomainService.CheckConnection(currentUserId, vm.UserId, true, true);
            vm.ConnectionControl.CurrentUserWantsToFollowMe = this.userConnectionDomainService.CheckConnection(vm.UserId, currentUserId, false, false);
            vm.ConnectionControl.ConnectionIsPending = this.userConnectionDomainService.CheckConnection(currentUserId, vm.UserId, false, true);

            return vm;
        }

        private static void FormatExternalNetworkUrls(ProfileViewModel vm)
        {
            if (!string.IsNullOrWhiteSpace(vm.ItchIoUrl))
            {
                vm.ItchIoUrl = vm.ItchIoUrl.ToLower().Replace(" ", "-");
                if (!vm.ItchIoUrl.EndsWith("itch.io"))
                {
                    vm.ItchIoUrl = "https://" + vm.ItchIoUrl + ".itch.io";
                }
            }

            if (!string.IsNullOrWhiteSpace(vm.GameJoltUrl))
            {
                vm.GameJoltUrl = vm.GameJoltUrl.ToLower().Replace(" ", "-");
                if (!vm.GameJoltUrl.EndsWith("itch.io"))
                {
                    vm.GameJoltUrl = "https://gamejolt.com/@" + vm.GameJoltUrl;
                }
            }

            if (!string.IsNullOrWhiteSpace(vm.UnityConnectUrl))
            {
                vm.UnityConnectUrl = vm.UnityConnectUrl.ToLower().Replace(" ", "-");
                if (!vm.UnityConnectUrl.EndsWith("itch.io"))
                {
                    vm.UnityConnectUrl = "https://connect.unity.com/u/" + vm.UnityConnectUrl;
                }
            }
        }

        public ProfileViewModel GenerateNewOne(ProfileType type)
        {
            ProfileViewModel profile = new ProfileViewModel();

            var randomGenerator = RandomNumberGenerator.Create();
            byte[] data = new byte[4];
            randomGenerator.GetBytes(data);
            var randomNumber = BitConverter.ToInt32(data);

            profile.Type = ProfileType.Personal;

            profile.Name = String.Format("NPC {0}", Math.Abs(randomNumber));
            profile.Motto = "It is dangerous out there, take this...";

            profile.Bio = profile.Name + " is a game developer willing to rock the game development world with funny games.";

            profile.StudioName = "Awesome Game Studio";
            profile.Location = "Atlantis";

            profile.ProfileImageUrl = Constants.DefaultAvatar;
            profile.CoverImageUrl = Constants.DefaultGameCoverImage;

            return profile;
        }
        #endregion
    }
}
