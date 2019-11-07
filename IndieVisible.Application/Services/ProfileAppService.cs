using AutoMapper;
using AutoMapper.QueryableExtensions;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.Core.Interfaces;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.Specifications.Follow;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
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
        private readonly IUserContentDomainService userContentDomainService;

        private readonly IGameRepository gameRepository;

        public ProfileAppService(IMapper mapper
            , IUnitOfWork unitOfWork
            , IProfileDomainService profileDomainService
            , IUserContentDomainService userContentDomainService
            , IGameRepository gameRepositoryMongo)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.profileDomainService = profileDomainService;
            this.userContentDomainService = userContentDomainService;
            gameRepository = gameRepositoryMongo;
        }

        #region ICrudAppService
        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = profileDomainService.Count();

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

                viewModel.ExternalLinks.RemoveAll(x => String.IsNullOrWhiteSpace(x.Value));

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

            vm.Counters.Games = gameRepository.Count(x => x.UserId == vm.UserId).Result;
            vm.Counters.Posts = userContentDomainService.Count(x => x.UserId == vm.UserId);
            vm.Counters.Comments = userContentDomainService.CountComments(x => x.UserId == vm.UserId);

            vm.Counters.Followers = model.Followers.SafeCount();
            vm.Counters.Following = profileDomainService.CountFollow(x => x.UserId == userId);
            int connectionsToUser = profileDomainService.CountConnections(x => x.TargetUserId == vm.UserId && x.ApprovalDate.HasValue);
            int connectionsFromUser = profileDomainService.CountConnections(x => x.UserId == vm.UserId && x.ApprovalDate.HasValue);

            vm.Counters.Connections = connectionsToUser + connectionsFromUser;


            if (vm.UserId != currentUserId)
            {
                vm.CurrentUserFollowing = profileDomainService.GetFollows(x => x.UserId == currentUserId && x.FollowUserId == vm.UserId).Any();
                vm.ConnectionControl.CurrentUserConnected = profileDomainService.CheckConnection(currentUserId, vm.UserId, true, true);
                vm.ConnectionControl.CurrentUserWantsToFollowMe = profileDomainService.CheckConnection(vm.UserId, currentUserId, false, false);
                vm.ConnectionControl.ConnectionIsPending = profileDomainService.CheckConnection(currentUserId, vm.UserId, false, true); 
            }

            return vm;
        }
        #endregion

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

        public OperationResultVo UserFollow(Guid currentUserId, Guid userId)
        {
            try
            {
                UserFollow model = new UserFollow
                {
                    FollowUserId = userId,
                    UserId = currentUserId
                };

                ISpecification<UserFollow> spec = new IdsNotEmptySpecification()
                    .And(new UserNotTheSameSpecification(currentUserId));

                if (!spec.IsSatisfiedBy(model))
                {
                    return new OperationResultVo(false, spec.ErrorMessage);
                }

                bool alreadyFollowing = profileDomainService.CheckFollowing(currentUserId, userId);

                if (alreadyFollowing)
                {
                    return new OperationResultVo(false, "User already followed");
                }
                else
                {
                    profileDomainService.AddFollow(model);

                    unitOfWork.Commit();

                    int newCount = profileDomainService.CountFollow(x => x.FollowUserId == userId);

                    return new OperationResultVo<int>(newCount);

                }
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo UserUnfollow(Guid currentUserId, Guid userId)
        {
            try
            {
                if (currentUserId == Guid.Empty)
                {
                    return new OperationResultVo("You must be logged in to unfollow a user.");
                }
                else
                {
                    UserFollow existingFollow = profileDomainService.GetFollows(x => x.UserId == currentUserId && x.FollowUserId == userId).FirstOrDefault();

                    if (existingFollow == null)
                    {
                        return new OperationResultVo(false, "You are not following this user.");
                    }
                    else
                    {
                        profileDomainService.RemoveFollow(existingFollow);

                        unitOfWork.Commit();

                        int newCount = profileDomainService.CountFollow(x => x.FollowUserId == userId);

                        return new OperationResultVo<int>(newCount);
                    }
                }
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        #region UserConnection
        public OperationResultVo GetConnectionsByUserId(Guid userId)
        {
            try
            {
                List<UserConnection> connectionsFromDb = profileDomainService.GetConnectionsByUserId(userId, true);

                var connections = mapper.Map<List<UserConnectionViewModel>>(connectionsFromDb);

                var connectionsFormatted = FormatConnections(userId, connections);

                return new OperationResultListVo<UserConnectionViewModel>(connectionsFormatted);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo Connect(Guid currentUserId, Guid userId)
        {
            try
            {
                UserConnection model = new UserConnection
                {
                    UserId = currentUserId,
                    TargetUserId = userId
                };

                UserConnection existing = profileDomainService.GetConnection(currentUserId, userId);

                if (existing != null)
                {
                    return new OperationResultVo("You are already connected to this user!");
                }
                else
                {
                    profileDomainService.AddConnection(model);
                }

                unitOfWork.Commit();

                int newCount = profileDomainService.CountConnections(x => x.TargetUserId == userId || x.UserId == userId && x.ApprovalDate.HasValue);

                return new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo Disconnect(Guid currentUserId, Guid userId)
        {
            try
            {
                // validate before

                UserConnection toMe = profileDomainService.GetConnection(currentUserId, userId);
                UserConnection fromMe = profileDomainService.GetConnection(userId, currentUserId);

                if (toMe == null && fromMe == null)
                {
                    return new OperationResultVo("You are not connected to this user!");
                }
                else
                {
                    if (toMe != null)
                    {
                        profileDomainService.RemoveConnection(toMe.Id);
                    }
                    if (fromMe != null)
                    {
                        profileDomainService.RemoveConnection(fromMe.Id);
                    }
                }

                unitOfWork.Commit();

                int newCount = profileDomainService.CountConnections(x => x.TargetUserId == userId);

                return new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo Allow(Guid currentUserId, Guid userId)
        {
            try
            {
                UserConnection existing = profileDomainService.GetConnection(userId, currentUserId);

                if (existing == null)
                {
                    return new OperationResultVo("There is no connection requested by this user.");
                }
                else
                {
                    existing.ApprovalDate = DateTime.Now;

                    profileDomainService.UpdateConnection(existing);
                }

                unitOfWork.Commit();

                int newCount = profileDomainService.CountConnections(x => x.TargetUserId == userId || x.UserId == userId && x.ApprovalDate.HasValue);

                return new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo Deny(Guid currentUserId, Guid userId)
        {
            try
            {
                UserConnection existing = profileDomainService.GetConnection(userId, currentUserId);

                if (existing == null)
                {
                    return new OperationResultVo("There is no connection requested by this user.");
                }
                else
                {
                    profileDomainService.RemoveConnection(existing.Id);
                }

                unitOfWork.Commit();

                int newCount = profileDomainService.CountConnections(x => x.TargetUserId == userId || x.UserId == userId && x.ApprovalDate.HasValue);

                return new OperationResultVo<int>(newCount);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }
        #endregion


        private List<UserConnectionViewModel> FormatConnections(Guid userId, IEnumerable<UserConnectionViewModel> connections)
        {
            List<UserConnectionViewModel> newList = new List<UserConnectionViewModel>();

            IEnumerable<UserConnectionViewModel> connectionsFromMe = connections.Where(x => x.UserId == userId && x.ApprovalDate.HasValue).ToList();
            IEnumerable<UserConnectionViewModel> connectionsToMe = connections.Where(x => x.TargetUserId == userId && x.ApprovalDate.HasValue).ToList();

            foreach (UserConnectionViewModel item in connectionsFromMe)
            {
                if (!newList.Any(x => x.UserId == item.TargetUserId))
                {
                    UserProfileEssentialVo profile = profileDomainService.GetBasicDataByUserId(item.TargetUserId);

                    item.TargetUserId = item.TargetUserId;
                    item.UserId = userId;
                    item.TargetUserName = profile.Name;
                    item.Location = profile.Location;
                    item.CreateDate = profile.CreateDate;

                    FormatConnectionImages(item, profile.Id);

                    newList.Add(item);
                }
            }

            foreach (var item in connectionsToMe)
            {
                if (!newList.Any(x => x.UserId == item.UserId))
                {
                    UserProfileEssentialVo profile = profileDomainService.GetBasicDataByUserId(item.UserId);

                    item.TargetUserId = item.UserId;
                    item.UserId = userId;
                    item.TargetUserName = profile.Name;
                    item.ProfileId = profile.Id;
                    item.Location = profile.Location;
                    item.CreateDate = profile.CreateDate;

                    FormatConnectionImages(item, profile.Id);

                    newList.Add(item);
                }
            }

            return newList;
        }

        private static void FormatConnectionImages(UserConnectionViewModel item, Guid profileId)
        {
            item.ProfileImageUrl = UrlFormatter.ProfileImage(item.TargetUserId);
            item.CoverImageUrl = UrlFormatter.ProfileCoverImage(item.TargetUserId, profileId);
        }
    }
}
