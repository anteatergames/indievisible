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
        private readonly IProfileDomainService profileDomainService;
        private readonly IGameRepository gameRepository;
        private readonly IUserContentDomainService userContentDomainService;
        private readonly IBrainstormCommentRepository brainstormCommentRepository;
        private readonly IUserConnectionDomainService userConnectionDomainService;

        public ProfileAppService(IMapper mapper, IUnitOfWork unitOfWork
            , IProfileDomainService profileDomainService
            , IGameRepository gameRepository
            , IUserContentDomainService userContentDomainService
            , IBrainstormCommentRepository brainstormCommentRepositor
            , IUserConnectionDomainService userConnectionDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.profileDomainService = profileDomainService;
            this.gameRepository = gameRepository;
            this.userContentDomainService = userContentDomainService;
            this.brainstormCommentRepository = brainstormCommentRepositor;
            this.userConnectionDomainService = userConnectionDomainService;
        }

        #region ICrudAppService Implementation
        public OperationResultVo<int> Count()
        {
            OperationResultVo<int> result;

            try
            {
                int count = profileDomainService.GetAll().Count();

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
                var allModels = profileDomainService.GetAll();

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
                UserProfile model = profileDomainService.GetById(id);

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

                profileDomainService.Remove(id);

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

                #region Update Name
                IQueryable<Game> games = gameRepository.GetAll().Where(x => x.UserId == viewModel.UserId);

                foreach (Game g in games)
                {
                    g.DeveloperName = viewModel.Name;
                }

                IEnumerable<UserContent> posts = userContentDomainService.Get(x => x.UserId == viewModel.UserId);

                foreach (UserContent p in posts)
                {
                    p.AuthorName = viewModel.Name;
                }

                IEnumerable<UserContentComment> comments = userContentDomainService.GetAllComments(x => x.UserId == viewModel.UserId);

                foreach (UserContentComment c in comments)
                {
                    c.AuthorName = viewModel.Name;
                }

                IEnumerable<BrainstormComment> brainstormComments = brainstormCommentRepository.GetAll().Where(x => x.UserId == viewModel.UserId);

                foreach (BrainstormComment bc in brainstormComments)
                {
                    bc.AuthorName = viewModel.Name;
                }
                #endregion

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


            vm.Counters.Followers = this.profileDomainService.CountFollow(x => x.FollowUserId == vm.UserId);
            vm.Counters.Following = this.profileDomainService.CountFollow(x => x.UserId == currentUserId);
            int connectionsToUser = this.userConnectionDomainService.Count(x => x.TargetUserId == vm.UserId && x.ApprovalDate.HasValue);
            int connectionsFromUser = this.userConnectionDomainService.Count(x => x.UserId == vm.UserId && x.ApprovalDate.HasValue);

            vm.Counters.Connections = connectionsToUser + connectionsFromUser;


            //unitOfWork.Commit();

            vm.CurrentUserFollowing = this.profileDomainService.GetFollows(x => x.UserId == currentUserId && x.FollowUserId == vm.UserId).Any();
            vm.ConnectionControl.CurrentUserConnected = this.userConnectionDomainService.CheckConnection(currentUserId, vm.UserId, true, true);
            vm.ConnectionControl.CurrentUserWantsToFollowMe = this.userConnectionDomainService.CheckConnection(vm.UserId, currentUserId, false, false);
            vm.ConnectionControl.ConnectionIsPending = this.userConnectionDomainService.CheckConnection(currentUserId, vm.UserId, false, true);

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
        #endregion
    }
}
