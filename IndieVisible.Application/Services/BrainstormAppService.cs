using AutoMapper;
using AutoMapper.QueryableExtensions;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Brainstorm;
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

namespace IndieVisible.Application.Services
{
    public class BrainstormAppService : BaseAppService, IBrainstormAppService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IBrainstormSessionRepository brainstormSessionRepository;
        private readonly IBrainstormIdeaRepository brainstormIdeaRepository;
        private readonly IBrainstormVoteRepository brainstormVoteRepository;
        private readonly IBrainstormCommentRepository brainstormCommentRepository;
        private readonly IGamificationDomainService gamificationDomainService;

        public BrainstormAppService(IMapper mapper, IUnitOfWork unitOfWork
            , IBrainstormSessionRepository brainstormSessionRepository, IBrainstormIdeaRepository brainstormIdeaRepository, IBrainstormVoteRepository brainstormVoteRepository, IBrainstormCommentRepository brainstormCommentRepository
            , IGamificationDomainService gamificationDomainService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.brainstormIdeaRepository = brainstormIdeaRepository;
            this.brainstormSessionRepository = brainstormSessionRepository;
            this.brainstormVoteRepository = brainstormVoteRepository;
            this.brainstormCommentRepository = brainstormCommentRepository;
            this.gamificationDomainService = gamificationDomainService;
        }

        #region ICrudAppService
        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = brainstormIdeaRepository.GetAll().Count();

                return new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<int>(ex.Message);
            }
        }

        public OperationResultListVo<BrainstormIdeaViewModel> GetAll(Guid currentUserId)
        {
            try
            {
                IQueryable<BrainstormIdea> allModels = brainstormIdeaRepository.GetAll();

                IQueryable<BrainstormVote> currentUserVotes = brainstormVoteRepository.GetByUserId(currentUserId);

                IEnumerable<BrainstormIdeaViewModel> vms = mapper.Map<IEnumerable<BrainstormIdea>, IEnumerable<BrainstormIdeaViewModel>>(allModels);

                foreach (BrainstormIdeaViewModel item in vms)
                {
                    item.UserContentType = UserContentType.Idea;
                    item.VoteCount = brainstormVoteRepository.Count(x => x.IdeaId == item.Id);
                    item.Score = brainstormVoteRepository.GetAll().Where(x => x.IdeaId == item.Id).Sum(x => (int)x.VoteValue);
                    item.CurrentUserVote = currentUserVotes.FirstOrDefault(x => x.IdeaId == item.Id)?.VoteValue ?? VoteValue.Neutral;

                    item.CommentCount = brainstormCommentRepository.Count(x => x.IdeaId == item.Id);
                }

                vms = vms.OrderByDescending(x => x.Score).ThenByDescending(x => x.CreateDate);

                return new OperationResultListVo<BrainstormIdeaViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<BrainstormIdeaViewModel>(ex.Message);
            }
        }

        public OperationResultVo<BrainstormIdeaViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                BrainstormIdea model = brainstormIdeaRepository.GetById(id);
                BrainstormSession session = brainstormSessionRepository.GetById(model.SessionId);

                BrainstormIdeaViewModel vm = mapper.Map<BrainstormIdeaViewModel>(model);

                vm.UserContentType = UserContentType.Idea;
                vm.VoteCount = brainstormVoteRepository.Count(x => x.IdeaId == vm.Id);
                vm.Score = brainstormVoteRepository.GetAll().Where(x => x.IdeaId == vm.Id).Sum(x => (int)x.VoteValue);
                vm.CurrentUserVote = brainstormVoteRepository.GetAll().FirstOrDefault(x => x.UserId == currentUserId && x.IdeaId == id)?.VoteValue ?? VoteValue.Neutral;

                vm.CommentCount = brainstormCommentRepository.GetAll().Count(x => x.IdeaId == vm.Id);

                IOrderedQueryable<BrainstormComment> comments = brainstormCommentRepository.GetAll().Where(x => x.IdeaId == vm.Id).OrderBy(x => x.CreateDate);

                IQueryable<BrainstormCommentViewModel> commentsVm = comments.ProjectTo<BrainstormCommentViewModel>(mapper.ConfigurationProvider);

                vm.Comments = commentsVm.ToList();

                foreach (BrainstormCommentViewModel comment in vm.Comments)
                {
                    comment.AuthorName = string.IsNullOrWhiteSpace(comment.AuthorName) ? "Unknown soul" : comment.AuthorName;
                    comment.AuthorPicture = UrlFormatter.ProfileImage(comment.UserId);
                    comment.Text = string.IsNullOrWhiteSpace(comment.Text) ? "this is the sound... of silence..." : comment.Text;
                }

                vm.Permissions.CanEdit = currentUserId == session.UserId;

                return new OperationResultVo<BrainstormIdeaViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<BrainstormIdeaViewModel>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            try
            {
                // validate before

                brainstormIdeaRepository.Remove(id);

                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, BrainstormIdeaViewModel viewModel)
        {
            try
            {
                BrainstormIdea model;

                BrainstormIdea existing = brainstormIdeaRepository.GetById(viewModel.Id);
                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<BrainstormIdea>(viewModel);
                }

                if (viewModel.Id == Guid.Empty)
                {
                    BrainstormSession session = brainstormSessionRepository.GetAll().FirstOrDefault(x => x.Type == BrainstormSessionType.Main);

                    model.SessionId = session.Id;

                    brainstormIdeaRepository.Add(model);
                    viewModel.Id = model.Id;

                    gamificationDomainService.ProcessAction(viewModel.UserId, PlatformAction.IdeaSuggested);
                }
                else
                {
                    brainstormIdeaRepository.Update(model);
                }

                unitOfWork.Commit();

                return new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }
        #endregion

        public OperationResultVo Vote(Guid userId, Guid ideaId, VoteValue vote)
        {
            try
            {
                BrainstormVote model;

                BrainstormVote existing = brainstormVoteRepository.Get(ideaId, userId);
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
                        VoteValue = vote
                    };
                }

                if (model.Id == Guid.Empty)
                {
                    brainstormVoteRepository.Add(model);
                }
                else
                {
                    brainstormVoteRepository.Update(model);
                }

                unitOfWork.Commit();

                return new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }

        public OperationResultVo Comment(UserContentCommentViewModel vm)
        {
            try
            {
                BrainstormComment model = new BrainstormComment
                {
                    UserId = vm.UserId,
                    IdeaId = vm.UserContentId,
                    Text = vm.Text,
                    AuthorName = vm.AuthorName,
                    AuthorPicture = vm.AuthorPicture
                };

                brainstormCommentRepository.Add(model);

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
                IQueryable<BrainstormSession> allMain = brainstormSessionRepository.Get(x => x.Id == sessionId);

                BrainstormSession main = allMain.FirstOrDefault();

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
                BrainstormSession model = brainstormSessionRepository.GetAll().LastOrDefault(x => x.Type == type);

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
                IQueryable<BrainstormSession> model = brainstormSessionRepository.GetAll();

                IQueryable<BrainstormSessionViewModel> vms = model.ProjectTo<BrainstormSessionViewModel>(mapper.ConfigurationProvider);

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

                BrainstormSession existing = brainstormSessionRepository.GetById(vm.Id);
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
                    brainstormSessionRepository.Add(model);
                    vm.Id = model.Id;
                }
                else
                {
                    brainstormSessionRepository.Update(model);
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
                IQueryable<BrainstormIdea> allModels = brainstormIdeaRepository.GetAll().Where(x => x.SessionId == sessionId);

                IQueryable<BrainstormVote> currentUserVotes = brainstormVoteRepository.GetByUserId(userId);

                IEnumerable<BrainstormIdeaViewModel> vms = mapper.Map<IEnumerable<BrainstormIdea>, IEnumerable<BrainstormIdeaViewModel>>(allModels);

                foreach (BrainstormIdeaViewModel item in vms)
                {
                    item.UserContentType = UserContentType.Idea;
                    item.VoteCount = brainstormVoteRepository.Count(x => x.IdeaId == item.Id);
                    item.Score = brainstormVoteRepository.GetAll().Where(x => x.IdeaId == item.Id).Sum(x => (int)x.VoteValue);
                    item.CurrentUserVote = currentUserVotes.FirstOrDefault(x => x.IdeaId == item.Id)?.VoteValue ?? VoteValue.Neutral;

                    item.CommentCount = brainstormCommentRepository.Count(x => x.IdeaId == item.Id);
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
                IQueryable<BrainstormSession> allMain = brainstormSessionRepository.Get(x => x.Type == BrainstormSessionType.Main);

                BrainstormSession main = allMain.FirstOrDefault();

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
                BrainstormIdea idea = brainstormIdeaRepository.GetById(ideaId);

                if (idea == null)
                {
                    return new OperationResultVo("Idea not found!");
                }

                idea.Status = selectedStatus;

                brainstormIdeaRepository.Update(idea);

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
