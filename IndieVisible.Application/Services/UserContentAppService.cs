using AutoMapper;
using AutoMapper.QueryableExtensions;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.Poll;
using IndieVisible.Application.ViewModels.Search;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace IndieVisible.Application.Services
{
    public class UserContentAppService : BaseAppService, IUserContentAppService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserContentDomainService userContentDomainService;
        private readonly IGamificationDomainService gamificationDomainService;
        private readonly IPollDomainService pollDomainService;

        public UserContentAppService(IMapper mapper, IUnitOfWork unitOfWork
            , IUserContentDomainService userContentDomainService
            , IGamificationDomainService gamificationDomainService
            , IPollDomainService pollDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.userContentDomainService = userContentDomainService;
            this.gamificationDomainService = gamificationDomainService;
            this.pollDomainService = pollDomainService;
            this.pollDomainService = pollDomainService;
        }

        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = userContentDomainService.Count();

                return new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<int>(ex.Message);
            }
        }

        public OperationResultListVo<UserContentViewModel> GetAll(Guid currentUserId)
        {
            try
            {
                IEnumerable<UserContent> allModels = userContentDomainService.GetAll();

                IEnumerable<UserContentViewModel> vms = mapper.Map<IEnumerable<UserContent>, IEnumerable<UserContentViewModel>>(allModels);

                return new OperationResultListVo<UserContentViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<UserContentViewModel>(ex.Message);
            }
        }

        public OperationResultVo<UserContentViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                UserContent model = userContentDomainService.GetById(id);

                UserContentViewModel vm = mapper.Map<UserContentViewModel>(model);

                bool isYoutube = false;

                if (!string.IsNullOrWhiteSpace(vm.FeaturedImage))
                {
                    string youtubePattern = @"(https?\:\/\/)?(www\.youtube\.com|youtu\.?be)\/.+";

                    isYoutube = Regex.IsMatch(vm.FeaturedImage, youtubePattern);
                }

                vm.HasFeaturedImage = !string.IsNullOrWhiteSpace(vm.FeaturedImage) && !vm.FeaturedImage.Contains(Constants.DefaultFeaturedImage) && !isYoutube;

                vm.FeaturedMediaType = GetMediaType(vm.FeaturedImage);

                if (vm.FeaturedMediaType != MediaType.Youtube)
                {
                    vm.FeaturedImage = SetFeaturedImage(vm.UserId, vm.FeaturedImage);
                }

                LoadAuthenticatedData(currentUserId, vm);

                vm.Poll = SetPoll(currentUserId, vm.Id);

                return new OperationResultVo<UserContentViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<UserContentViewModel>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            try
            {
                pollDomainService.RemoveByContentId(id);

                userContentDomainService.Remove(id);

                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, UserContentViewModel viewModel)
        {
            try
            {
                int pointsEarned = 0;

                UserContent model;

                bool isSpam = CheckSpam(viewModel.Id, viewModel.Content);

                bool isNew = viewModel.Id == Guid.Empty;

                if (isSpam)
                {
                    return new OperationResultVo<Guid>("Calm down! You cannot post the same content twice in a row.");
                }

                string youtubePattern = @"(https?\:\/\/)?(www\.youtube\.com|youtu\.?be)\/.+";

                viewModel.Content = Regex.Replace(viewModel.Content, youtubePattern, delegate (Match match)
                {
                    string v = match.ToString();
                    if (match.Index == 0 && String.IsNullOrWhiteSpace(viewModel.FeaturedImage))
                    {
                        viewModel.FeaturedImage = v;
                    }
                    return v;
                });

                UserContent existing = userContentDomainService.GetById(viewModel.Id);
                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<UserContent>(viewModel);
                }

                if (isNew)
                {
                    userContentDomainService.Add(model);

                    PlatformAction action = viewModel.IsComplex ? PlatformAction.ComplexPost : PlatformAction.SimplePost;
                    pointsEarned += gamificationDomainService.ProcessAction(viewModel.UserId, action);

                    unitOfWork.Commit();
                    viewModel.Id = model.Id;

                    if (viewModel.Poll != null && viewModel.Poll.PollOptions != null && viewModel.Poll.PollOptions.Any())
                    {
                        CreatePoll(viewModel);

                        pointsEarned += gamificationDomainService.ProcessAction(viewModel.UserId, PlatformAction.PollPost);
                    }
                }
                else
                {
                    userContentDomainService.Update(model);
                }

                unitOfWork.Commit();

                return new OperationResultVo<Guid>(model.Id, pointsEarned);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }

        private bool CheckSpam(Guid id, string content)
        {
            IEnumerable<UserContent> all = userContentDomainService.GetAll();

            if (all.Any())
            {
                UserContent latest = all.OrderBy(x => x.CreateDate).Last();
                bool sameContent = latest.Content.Trim().ToLower().Replace(" ", string.Empty).Equals(content.Trim().ToLower().Replace(" ", string.Empty));
                bool sameId = latest.Id == id;

                return sameContent && !sameId;
            }
            else
            {
                return false;
            }
        }

        private void CreatePoll(UserContentViewModel contentVm)
        {
            Poll newPoll = new Poll
            {                
                UserId = contentVm.UserId,
                UserContentId = contentVm.Id
            };

            foreach (PollOptionViewModel o in contentVm.Poll.PollOptions)
            {
                PollOption newOption = new PollOption
                {
                    UserId = contentVm.UserId,
                    Text = o.Text
                };

                newPoll.Options.Add(newOption);
            }


            pollDomainService.Add(newPoll);
        }

        public int CountArticles()
        {
            int count = userContentDomainService.Count(x => !string.IsNullOrEmpty(x.Title) && !string.IsNullOrEmpty(x.Introduction) && !string.IsNullOrEmpty(x.FeaturedImage) && x.Content.Length > 50);

            return count;
        }

        public IEnumerable<UserContentViewModel> GetActivityFeed(ActivityFeedRequestViewModel vm)
        {
            var allModels = userContentDomainService.GetActivityFeed(vm.GameId, vm.UserId, vm.Languages, vm.OldestId, vm.OldestDate, vm.ArticlesOnly, vm.Count).ToList();

            try
            {
                IEnumerable<UserContentViewModel> viewModels = mapper.Map<IEnumerable<UserContent>, IEnumerable<UserContentViewModel>>(allModels);

                foreach (UserContentViewModel item in viewModels)
                {
                    item.AuthorName = string.IsNullOrWhiteSpace(item.AuthorName) ? "Unknown soul" : item.AuthorName;
                    item.AuthorPicture = UrlFormatter.ProfileImage(item.UserId);

                    item.IsArticle = !string.IsNullOrWhiteSpace(item.Title) && !string.IsNullOrWhiteSpace(item.Introduction);

                    item.HasFeaturedImage = !string.IsNullOrWhiteSpace(item.FeaturedImage) && !item.FeaturedImage.Contains(Constants.DefaultFeaturedImage);

                    item.FeaturedImageType = GetMediaType(item.FeaturedImage);

                    if (item.FeaturedImageType != MediaType.Youtube)
                    {
                        item.FeaturedImage = SetFeaturedImage(item.UserId, item.FeaturedImage);
                    }

                    item.LikeCount = item.Likes.Count;

                    item.CommentCount = item.Comments.Count;

                    item.Poll = SetPoll(vm.CurrentUserId, item.Id);

                    LoadAuthenticatedData(vm.CurrentUserId, item);
                }

                return viewModels;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public OperationResultListVo<UserContentSearchViewModel> Search(Guid currentUserId, string q)
        {
            try
            {
                IQueryable<UserContent> all = userContentDomainService.Search(x => x.Content.Contains(q) || x.Introduction.Contains(q)).AsQueryable();

                IQueryable<UserContentSearchVo> selected = all.OrderByDescending(x => x.CreateDate)
                    .Select(x => new UserContentSearchVo
                    {
                        ContentId = x.Id,
                        Title = x.Title,
                        FeaturedImage = x.FeaturedImage,
                        Content = (string.IsNullOrWhiteSpace(x.Introduction) ? x.Content : x.Introduction).GetFirstWords(20),
                        Language = x.Language
                    });

                IQueryable<UserContentSearchViewModel> vms = selected.ProjectTo<UserContentSearchViewModel>(mapper.ConfigurationProvider);

                return new OperationResultListVo<UserContentSearchViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<UserContentSearchViewModel>(ex.Message);
            }
        }

        private PollViewModel SetPoll(Guid currentUserId, Guid contentId)
        {
            PollViewModel pollVm = null;
            Poll poll = pollDomainService.GetByUserContentId(contentId);

            if (poll != null)
            {
                pollVm = new PollViewModel();

                int totalVotes = poll.Votes.Count;
                pollVm.TotalVotes = totalVotes;

                foreach (PollOption option in poll.Options)
                {
                    PollOptionViewModel loadedOption = new PollOptionViewModel
                    {
                        Id = option.Id,
                        Text = option.Text
                    };

                    loadedOption.Votes = poll.Votes.Count(x => x.PollOptionId == option.Id);
                    loadedOption.VotePercentage = loadedOption.Votes > 0 ? (loadedOption.Votes / (decimal)totalVotes) * 100 : 0;
                    loadedOption.CurrentUserVoted = poll.Votes.Any(x => x.PollOptionId == option.Id && x.UserId == currentUserId);

                    pollVm.PollOptions.Add(loadedOption);
                }
            }

            return pollVm;
        }

        private void LoadAuthenticatedData(Guid currentUserId, UserGeneratedCommentBaseViewModel<UserContentCommentViewModel> item)
        {
            if (currentUserId != Guid.Empty)
            {
                item.CurrentUserLiked = item.Likes.Any(x => x == currentUserId);

                foreach (UserContentCommentViewModel comment in item.Comments)
                {
                    comment.AuthorName = string.IsNullOrWhiteSpace(comment.AuthorName) ? "Unknown soul" : comment.AuthorName;
                    comment.AuthorPicture = UrlFormatter.ProfileImage(comment.UserId);
                    comment.Text = string.IsNullOrWhiteSpace(comment.Text) ? "this is the sound... of silence..." : comment.Text;
                }
            }
        }

        private static string SetFeaturedImage(Guid userId, string featuredImage)
        {
            return string.IsNullOrWhiteSpace(featuredImage) || featuredImage.Equals(Constants.DefaultFeaturedImage) ? Constants.DefaultFeaturedImage : UrlFormatter.Image(userId, BlobType.FeaturedImage, featuredImage);
        }

        public OperationResultVo ContentLike(Guid currentUserId, Guid targetId)
        {
            try
            {
                var likes = userContentDomainService.GetLikes(x => x.ContentId == targetId);
                bool alreadyLiked = likes.Any(x => x.UserId == currentUserId);

                if (alreadyLiked)
                {
                    return new OperationResultVo("Content already liked");
                }
                else
                {
                    UserContentLike model = new UserContentLike
                    {
                        ContentId = targetId,
                        UserId = currentUserId
                    };

                    userContentDomainService.AddLike(model);

                    unitOfWork.Commit();

                    int newCount = likes.Count() + 1;

                    return new OperationResultVo<int>(newCount);
                }
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo ContentUnlike(Guid currentUserId, Guid targetId)
        {
            try
            {
                var likes = userContentDomainService.GetLikes(x => x.ContentId == targetId);
                UserContentLike existingLike = likes.FirstOrDefault(x => x.ContentId == targetId && x.UserId == currentUserId);

                if (existingLike == null)
                {
                    return new OperationResultVo("Content not liked");
                }
                else
                {
                    userContentDomainService.RemoveLike(currentUserId, targetId);

                    unitOfWork.Commit();

                    int newCount = likes.Count() - 1;

                    return new OperationResultVo<int>(newCount);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public OperationResultVo Comment(UserContentCommentViewModel vm)
        {
            try
            {
                bool commentAlreadyExists = userContentDomainService.CheckIfCommentExists<UserContentComment>(x => x.UserContentId == vm.UserContentId && x.UserId == vm.UserId && x.Text.Equals(vm.Text));

                if (commentAlreadyExists)
                {
                    return new OperationResultVo(false)
                    {
                        Message = "Duplicated Comment"
                    };
                }
                else
                {
                    UserContentComment model = mapper.Map<UserContentComment>(vm);

                    userContentDomainService.Comment(model);

                    unitOfWork.Commit();

                    int newCount = userContentDomainService.CountComments(x => x.UserContentId == model.UserContentId && x.UserId == model.UserId);

                    return new OperationResultVo<int>(newCount);
                }
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }
    }
}