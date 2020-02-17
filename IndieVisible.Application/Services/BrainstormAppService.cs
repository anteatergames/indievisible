using AutoMapper;
using AutoMapper.QueryableExtensions;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels;
using IndieVisible.Application.ViewModels.Brainstorm;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces;
using IndieVisible.Domain.Interfaces.Infrastructure;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class BrainstormAppService : ProfileBaseAppService, IBrainstormAppService
    {
        private readonly IGamificationDomainService gamificationDomainService;

        private readonly IBrainstormDomainService brainstormDomainService;

        public BrainstormAppService(IMapper mapper
            , IUnitOfWork unitOfWork
            , ICacheService cacheService
            , IProfileDomainService profileDomainService
            , IGamificationDomainService gamificationDomainService
            , IBrainstormDomainService brainstormDomainService) : base(mapper, unitOfWork, cacheService, profileDomainService)
        {
            this.gamificationDomainService = gamificationDomainService;

            this.brainstormDomainService = brainstormDomainService;
        }

        #region ICrudAppService

        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = brainstormDomainService.Count();

                return new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<int>(ex.Message);
            }
        }

        public OperationResultListVo<BrainstormIdeaViewModel> GetAll(Guid currentUserId)
        {
            return new OperationResultListVo<BrainstormIdeaViewModel>("Not Implemented");
        }

        public OperationResultVo<BrainstormIdeaViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                BrainstormIdea idea = brainstormDomainService.GetIdea(id);
                Guid sessionUserId = brainstormDomainService.GetUserId(idea.SessionId);

                BrainstormIdeaViewModel vm = mapper.Map<BrainstormIdeaViewModel>(idea);

                vm.UserContentType = UserContentType.Idea;
                vm.VoteCount = idea.Votes.Count;
                vm.Score = idea.Votes.Sum(x => (int)x.VoteValue);
                vm.CurrentUserVote = idea.Votes.FirstOrDefault(x => x.UserId == currentUserId)?.VoteValue ?? VoteValue.Neutral;

                vm.CommentCount = idea.Comments.Count;

                IQueryable<CommentViewModel> commentsVm = idea.Comments.AsQueryable().ProjectTo<CommentViewModel>(mapper.ConfigurationProvider);

                vm.Comments = commentsVm.OrderBy(x => x.CreateDate).ToList();

                foreach (CommentViewModel comment in vm.Comments)
                {
                    UserProfile commenterProfile = GetCachedProfileByUserId(comment.UserId);
                    if (commenterProfile == null)
                    {
                        comment.AuthorName = Constants.UnknownSoul;
                    }
                    else
                    {
                        comment.AuthorName = commenterProfile.Name;
                    }

                    comment.AuthorPicture = UrlFormatter.ProfileImage(comment.UserId);
                    comment.Text = string.IsNullOrWhiteSpace(comment.Text) ? Constants.SoundOfSilence : comment.Text;
                }

                vm.Permissions.CanEdit = currentUserId == sessionUserId;

                return new OperationResultVo<BrainstormIdeaViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<BrainstormIdeaViewModel>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            return new OperationResultVo("Not Implemented");
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, BrainstormIdeaViewModel viewModel)
        {
            try
            {
                BrainstormSession session = brainstormDomainService.GetById(viewModel.SessionId);

                BrainstormIdea model;

                BrainstormIdea existing = brainstormDomainService.GetIdea(viewModel.Id);
                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<BrainstormIdea>(viewModel);
                }

                model.SessionId = session.Id;

                if (model.Id == Guid.Empty)
                {
                    brainstormDomainService.AddIdea(model);
                }
                else
                {
                    brainstormDomainService.UpdateIdea(model);
                }

                gamificationDomainService.ProcessAction(viewModel.UserId, PlatformAction.IdeaSuggested);

                unitOfWork.Commit();

                return new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }

        #endregion ICrudAppService

        public OperationResultVo Vote(Guid userId, Guid ideaId, VoteValue vote)
        {
            try
            {
                BrainstormVote model;
                BrainstormIdea idea = brainstormDomainService.GetIdea(ideaId);

                BrainstormVote existing = idea.Votes.FirstOrDefault(x => x.UserId == userId);
                if (existing != null)
                {
                    model = existing;
                    model.VoteValue = vote;
                }
                else
                {
                    model = new BrainstormVote
                    {
                        UserId = userId,
                        IdeaId = ideaId,
                        SessionId = idea.SessionId,
                        VoteValue = vote
                    };
                }

                if (model.Id == Guid.Empty)
                {
                    brainstormDomainService.AddVote(model);
                }
                else
                {
                    brainstormDomainService.UpdateVote(model);
                }

                unitOfWork.Commit();

                return new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }

        public OperationResultVo Comment(CommentViewModel vm)
        {
            try
            {
                BrainstormIdea idea = brainstormDomainService.GetIdea(vm.UserContentId);
                BrainstormComment model = new BrainstormComment
                {
                    UserId = vm.UserId,
                    IdeaId = vm.UserContentId,
                    SessionId = idea.SessionId,
                    Text = vm.Text,
                    AuthorName = vm.AuthorName,
                    AuthorPicture = vm.AuthorPicture
                };

                brainstormDomainService.AddComment(model);

                unitOfWork.Commit();

                return new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }

        public OperationResultVo<BrainstormSessionViewModel> GetSession(Guid sessionId)
        {
            try
            {
                BrainstormSession main = brainstormDomainService.GetById(sessionId);

                BrainstormSessionViewModel vm = mapper.Map<BrainstormSessionViewModel>(main);

                return new OperationResultVo<BrainstormSessionViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<BrainstormSessionViewModel>(ex.Message);
            }
        }

        /// <summary>
        /// Get the most recent session of type
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public OperationResultVo<BrainstormSessionViewModel> GetSession(Guid userId, BrainstormSessionType type)
        {
            try
            {
                BrainstormSession model = brainstormDomainService.GetAll().LastOrDefault(x => x.Type == type);

                BrainstormSessionViewModel vm = mapper.Map<BrainstormSessionViewModel>(model);

                return new OperationResultVo<BrainstormSessionViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<BrainstormSessionViewModel>(ex.Message);
            }
        }

        public OperationResultListVo<BrainstormSessionViewModel> GetSessions(Guid userId)
        {
            try
            {
                IEnumerable<BrainstormSession> allModels = brainstormDomainService.GetAll();

                IEnumerable<BrainstormSessionViewModel> vms = mapper.Map<IEnumerable<BrainstormSession>, IEnumerable<BrainstormSessionViewModel>>(allModels);

                vms = vms.OrderBy(x => x.Type).ThenBy(x => x.CreateDate);

                return new OperationResultListVo<BrainstormSessionViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<BrainstormSessionViewModel>(ex.Message);
            }
        }

        public OperationResultVo<Guid> SaveSession(BrainstormSessionViewModel vm)
        {
            try
            {
                BrainstormSession model;

                BrainstormSession existing = brainstormDomainService.GetById(vm.Id);
                if (existing != null)
                {
                    model = mapper.Map(vm, existing);
                }
                else
                {
                    model = mapper.Map<BrainstormSession>(vm);
                }

                if (vm.Id == Guid.Empty)
                {
                    brainstormDomainService.Add(model);
                    vm.Id = model.Id;
                }
                else
                {
                    brainstormDomainService.Update(model);
                }

                unitOfWork.Commit();

                return new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }

        public OperationResultListVo<BrainstormIdeaViewModel> GetAllBySessionId(Guid userId, Guid sessionId)
        {
            try
            {
                IEnumerable<BrainstormIdea> allIdeas = brainstormDomainService.GetIdeasBySession(sessionId);

                IEnumerable<BrainstormIdeaViewModel> vms = mapper.Map<IEnumerable<BrainstormIdea>, IEnumerable<BrainstormIdeaViewModel>>(allIdeas);

                foreach (BrainstormIdeaViewModel idea in vms)
                {
                    idea.UserContentType = UserContentType.Idea;
                    idea.VoteCount = idea.Votes.Count;
                    idea.Score = idea.Votes.Sum(x => (int)x.VoteValue);
                    idea.CurrentUserVote = idea.Votes.FirstOrDefault(x => x.UserId == userId)?.VoteValue ?? VoteValue.Neutral;

                    idea.CommentCount = idea.Comments.Count;
                }

                vms = vms.OrderByDescending(x => x.Score).ThenByDescending(x => x.CreateDate);

                return new OperationResultListVo<BrainstormIdeaViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<BrainstormIdeaViewModel>(ex.Message);
            }
        }

        public OperationResultVo<BrainstormSessionViewModel> GetMainSession()
        {
            try
            {
                BrainstormSession main = brainstormDomainService.Get(BrainstormSessionType.Main);

                BrainstormSessionViewModel vm = mapper.Map<BrainstormSessionViewModel>(main);

                return new OperationResultVo<BrainstormSessionViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<BrainstormSessionViewModel>(ex.Message);
            }
        }

        public OperationResultVo ChangeStatus(Guid currentUserId, Guid ideaId, BrainstormIdeaStatus selectedStatus)
        {
            try
            {
                BrainstormIdea idea = brainstormDomainService.GetIdea(ideaId);

                if (idea == null)
                {
                    return new OperationResultVo("Idea not found!");
                }

                idea.Status = selectedStatus;

                brainstormDomainService.UpdateIdea(idea);

                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }
    }
}