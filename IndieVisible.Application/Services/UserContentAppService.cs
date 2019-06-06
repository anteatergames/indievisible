using AutoMapper;
using AutoMapper.QueryableExtensions;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
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
        private readonly IUserContentRepository repository;
        private readonly IUserContentLikeRepository likeRepository;
        private readonly IUserContentCommentRepository commentRepository;
        private readonly IGamificationDomainService gamificationDomainService;

        public UserContentAppService(IMapper mapper, IUnitOfWork unitOfWork
            , IUserContentRepository repository
            , IUserContentLikeRepository likeRepository, IUserContentCommentRepository commentRepository
            , IGamificationDomainService gamificationDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.likeRepository = likeRepository;
            this.commentRepository = commentRepository;
            this.gamificationDomainService = gamificationDomainService;
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

        public OperationResultListVo<UserContentViewModel> GetAll()
        {
            OperationResultListVo<UserContentViewModel> result;

            try
            {
                IQueryable<UserContent> allModels = repository.GetAll();

                IEnumerable<UserContentViewModel> vms = mapper.Map<IEnumerable<UserContent>, IEnumerable<UserContentViewModel>>(allModels);

                result = new OperationResultListVo<UserContentViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<UserContentViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<UserContentViewModel> GetById(Guid id)
        {
            OperationResultVo<UserContentViewModel> result;

            try
            {
                UserContent model = repository.GetById(id);

                UserContentViewModel vm = mapper.Map<UserContentViewModel>(model);


                vm.Content = FormatContentToShow(vm.Content);

                vm.UserContentType = UserContentType.Post;

                vm.HasFeaturedImage = !string.IsNullOrWhiteSpace(vm.FeaturedImage) && !vm.FeaturedImage.Contains(Constants.DefaultFeaturedImage);

                vm.FeaturedMediaType = GetMediaType(vm.FeaturedImage);

                if (vm.FeaturedMediaType != MediaType.Youtube)
                {
                    vm.FeaturedImage = SetFeaturedImage(vm.UserId, vm.FeaturedImage);
                }


                result = new OperationResultVo<UserContentViewModel>(vm);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<UserContentViewModel>(ex.Message);
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

        public OperationResultVo<Guid> Save(UserContentViewModel viewModel)
        {
            OperationResultVo<Guid> result;

            try
            {
                UserContent model;

                UserContent latest = repository.GetAll().OrderBy(x => x.CreateDate).Last();
                bool sameContent = latest.Content.Trim().ToLower().Replace(" ", string.Empty).Equals(viewModel.Content.Trim().ToLower().Replace(" ", string.Empty));
                bool sameId = latest.Id == viewModel.Id;

                if (sameContent && !sameId)
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
                        return String.Empty;
                    }
                    else
                    {
                        return string.Format(@"<a href=""{0}"">{0}</a>", v);
                    }

                });

                UserContent existing = repository.GetById(viewModel.Id);
                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<UserContent>(viewModel);

                    PlatformAction action = viewModel.IsComplex ? PlatformAction.ComplexPost : PlatformAction.SimplePost;

                    this.gamificationDomainService.ProcessAction(viewModel.UserId, action);
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

                unitOfWork.Commit();

                result = new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<Guid>(ex.Message);
            }

            return result;
        }

        public int CountArticles()
        {
            int count = repository.Count(x => !string.IsNullOrWhiteSpace(x.Title) && !string.IsNullOrWhiteSpace(x.Introduction));

            return count;
        }

        public IEnumerable<UserContentListItemViewModel> GetActivityFeed(Guid currentUserId, int count, Guid gameId, Guid userId, List<SupportedLanguage> languages)
        {
            IQueryable<UserContent> allModels = repository.GetAll();

            allModels = FilterActivityFeed(gameId, userId, languages, allModels);

            IOrderedQueryable<UserContent> orderedList = allModels
                .OrderByDescending(x => x.CreateDate);

            IQueryable<UserContent> finalList = orderedList.Take(count);

            List<UserContentListItemViewModel> viewModels = finalList.ProjectTo<UserContentListItemViewModel>(mapper.ConfigurationProvider).ToList();

            foreach (UserContentListItemViewModel item in viewModels)
            {
                item.AuthorName = string.IsNullOrWhiteSpace(item.AuthorName) ? "Unknown soul" : item.AuthorName;
                item.AuthorPicture = UrlFormatter.ProfileImage(item.UserId);

                item.IsArticle = !string.IsNullOrWhiteSpace(item.Title) && !string.IsNullOrWhiteSpace(item.Introduction);

                item.HasFeaturedImage = !string.IsNullOrWhiteSpace(item.FeaturedImage) && !item.FeaturedImage.Contains(Constants.DefaultFeaturedImage);

                item.FeaturedImageType = this.GetMediaType(item.FeaturedImage);

                if (item.FeaturedImageType != MediaType.Youtube)
                {
                    item.FeaturedImage = SetFeaturedImage(item.UserId, item.FeaturedImage);
                }

                item.LikeCount = likeRepository.GetAll().Count(x => x.ContentId == item.Id);

                item.CommentCount = commentRepository.GetAll().Count(x => x.UserContentId == item.Id);

                LoadAuthenticatedData(currentUserId, item);

                item.Content = FormatContentToShow(item.Content);
                item.UserContentType = UserContentType.Post;
            }

            return viewModels;
        }

        private void LoadAuthenticatedData(Guid currentUserId, UserContentListItemViewModel item)
        {
            if (currentUserId != Guid.Empty)
            {
                item.CurrentUserLiked = likeRepository.GetAll().Any(x => x.ContentId == item.Id && x.UserId == currentUserId);

                IOrderedQueryable<UserContentComment> comments = commentRepository.GetAll().Where(x => x.UserContentId == item.Id).OrderBy(x => x.CreateDate);

                IQueryable<UserContentCommentViewModel> commentsVm = comments.ProjectTo<UserContentCommentViewModel>(mapper.ConfigurationProvider);

                item.Comments = commentsVm.ToList();

                foreach (UserContentCommentViewModel comment in item.Comments)
                {
                    comment.AuthorName = string.IsNullOrWhiteSpace(comment.AuthorName) ? "Unknown soul" : comment.AuthorName;
                    comment.AuthorPicture = UrlFormatter.ProfileImage(comment.UserId);
                    comment.Text = string.IsNullOrWhiteSpace(comment.Text) ? "this is the sound... of silence..." : comment.Text;
                }
            }
        }

        private static IQueryable<UserContent> FilterActivityFeed(Guid gameId, Guid userId, List<SupportedLanguage> languages, IQueryable<UserContent> allModels)
        {
            if (userId != Guid.Empty)
            {
                allModels = allModels.Where(x => x.UserId != Guid.Empty && x.UserId == userId);
            }

            if (gameId != Guid.Empty)
            {
                allModels = allModels.Where(x => x.GameId != Guid.Empty && x.GameId == gameId);
            }

            if (languages != null && languages.Any())
            {
                allModels = allModels.Where(x => x.Language == 0 || languages.Contains(x.Language));
            }

            return allModels;
        }

        private static string SetFeaturedImage(Guid userId, string featuredImage)
        {
            return string.IsNullOrWhiteSpace(featuredImage) || featuredImage.Equals(Constants.DefaultFeaturedImage) ? Constants.DefaultFeaturedImage : UrlFormatter.Image(userId, BlobType.FeaturedImage, featuredImage);
        }

        private string FormatContentToShow(string content)
        {
            string patternUrl = @"(<img(.?)?(data-)?src="")?(\()?([(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*))""?(\))?(.>)?";

            Regex regexImage = new Regex(patternUrl);

            MatchCollection matchesImg = regexImage.Matches(content);

            foreach (Match match in matchesImg)
            {
                string toReplace = match.Groups[0].Value;
                string urlBefore = match.Groups[1].Value;
                string url = match.Groups[5].Value;

                url = !toReplace.TrimStart('(').TrimEnd(')').ToLower().StartsWith("http") ? String.Format("http://{0}", url) : url;

                string newText = string.Empty;
                if (string.IsNullOrWhiteSpace(urlBefore))
                {
                    newText = string.Format(@"<a href=""{0}"" target=""_blank"" style=""font-weight:500"">{0}</a>", url);
                }
                else
                {
                    newText = String.Format("<img src=\"{0}\" />", url);
                }

                content = content.Replace(toReplace, newText);
            }

            return content;
        }
    }
}
