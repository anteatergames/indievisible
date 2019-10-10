using AutoMapper;
using AutoMapper.QueryableExtensions;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
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
        private readonly IProfileDomainService profileDomainService;
        private readonly IGameRepository gameRepository;
        private readonly IUserContentDomainService userContentDomainService;
        private readonly IUserConnectionDomainService userConnectionDomainService;

        public ProfileAppService(IMapper mapper, IUnitOfWork unitOfWork
            , IProfileDomainService profileDomainService
            , IGameRepository gameRepository
            , IUserContentDomainService userContentDomainService
            , IUserConnectionDomainService userConnectionDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.profileDomainService = profileDomainService;
            this.gameRepository = gameRepository;
            this.userContentDomainService = userContentDomainService;
            this.userConnectionDomainService = userConnectionDomainService;
        }

        #region ICrudAppService
        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = profileDomainService.GetAll().Count();

                return new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<int>(ex.Message);
            }
        }

        public OperationResultListVo<ProfileViewModel> GetAll(Guid currentUserId)
        {
            try
            {
                IEnumerable<UserProfile> allModels = profileDomainService.GetAll();

                IEnumerable<ProfileViewModel> vms = mapper.Map<IEnumerable<UserProfile>, IEnumerable<ProfileViewModel>>(allModels);

                return new OperationResultListVo<ProfileViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<ProfileViewModel>(ex.Message);
            }
        }

        public OperationResultVo<ProfileViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                UserProfile model = profileDomainService.GetById(id);

                ProfileViewModel vm = mapper.Map<ProfileViewModel>(model);

                return new OperationResultVo<ProfileViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<ProfileViewModel>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            try
            {
                // validate before

                profileDomainService.Remove(id);

                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, ProfileViewModel viewModel)
        {
            try
            {
                UserProfile model;

                viewModel.GameJoltUrl = viewModel.GameJoltUrl?.TrimStart('@');

                UserProfile existing = profileDomainService.GetById(viewModel.Id);
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
                    profileDomainService.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    profileDomainService.Update(model);
                }

                profileDomainService.UpdateNameOnThePlatform(viewModel.UserId, viewModel.Name);

                unitOfWork.Commit();

                return new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }
        #endregion

        #region IProfileAppService
        public ProfileViewModel GetByUserId(Guid userId, ProfileType type)
        {
            return GetByUserId(userId, userId, type);
        }

        public ProfileViewModel GetByUserId(Guid currentUserId, Guid userId, ProfileType type)
        {
            ProfileViewModel vm = new ProfileViewModel();

            IEnumerable<UserProfile> profiles = profileDomainService.GetByUserId(userId);
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

            vm.Counters.Games = gameRepository.Count(x => x.UserId == vm.UserId);
            vm.Counters.Posts = userContentDomainService.Count(x => x.UserId == vm.UserId);
            vm.Counters.Comments = userContentDomainService.CountComments(x => x.UserId == vm.UserId);


            vm.Counters.Followers = profileDomainService.CountFollow(x => x.FollowUserId == vm.UserId);
            vm.Counters.Following = profileDomainService.CountFollow(x => x.UserId == currentUserId);
            int connectionsToUser = userConnectionDomainService.Count(x => x.TargetUserId == vm.UserId && x.ApprovalDate.HasValue);
            int connectionsFromUser = userConnectionDomainService.Count(x => x.UserId == vm.UserId && x.ApprovalDate.HasValue);

            vm.Counters.Connections = connectionsToUser + connectionsFromUser;

            vm.CurrentUserFollowing = profileDomainService.GetFollows(x => x.UserId == currentUserId && x.FollowUserId == vm.UserId).Any();
            vm.ConnectionControl.CurrentUserConnected = userConnectionDomainService.CheckConnection(currentUserId, vm.UserId, true, true);
            vm.ConnectionControl.CurrentUserWantsToFollowMe = userConnectionDomainService.CheckConnection(vm.UserId, currentUserId, false, false);
            vm.ConnectionControl.ConnectionIsPending = userConnectionDomainService.CheckConnection(currentUserId, vm.UserId, false, true);

            return vm;
        }

        public ProfileViewModel GenerateNewOne(ProfileType type)
        {
            ProfileViewModel profile = new ProfileViewModel();

            RandomNumberGenerator randomGenerator = RandomNumberGenerator.Create();
            byte[] data = new byte[4];
            randomGenerator.GetBytes(data);
            int randomNumber = BitConverter.ToInt32(data);

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

        public OperationResultVo Search(string term)
        {
            try
            {
                IQueryable<UserProfile> results = profileDomainService.Search(x => x.Name.ToLower().Contains(term.ToLower()));

                IQueryable<ProfileSearchViewModel> vms = results.ProjectTo<ProfileSearchViewModel>(mapper.ConfigurationProvider);

                return new OperationResultListVo<ProfileSearchViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }
        #endregion
    }
}
