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

        public OperationResultVo<int> Count()
        {
            OperationResultVo<int> result;

            try
            {
                int count = brainstormIdeaRepository.GetAll().Count();

                result = new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<int>(ex.Message);
            }

            return result;
        }

        public OperationResultListVo<BrainstormIdeaViewModel> GetAll()
        {
            OperationResultListVo<BrainstormIdeaViewModel> result;

            try
            {
                IQueryable<BrainstormIdea> allModels = brainstormIdeaRepository.GetAll();

                IEnumerable<BrainstormIdeaViewModel> vms = mapper.Map<IEnumerable<BrainstormIdea>, IEnumerable<BrainstormIdeaViewModel>>(allModels);

                vms = vms.OrderByDescending(x => x.VoteCount).ThenByDescending(x => x.CreateDate);

                result = new OperationResultListVo<BrainstormIdeaViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<BrainstormIdeaViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<BrainstormIdeaViewModel> GetById(Guid id)
        {
            OperationResultVo<BrainstormIdeaViewModel> result;

            try
            {
                BrainstormIdea model = brainstormIdeaRepository.GetById(id);

                BrainstormIdeaViewModel vm = mapper.Map<BrainstormIdeaViewModel>(model);


                vm.VoteCount = brainstormVoteRepository.Count(x => x.IdeaId == vm.Id);
                vm.Score = brainstormVoteRepository.GetAll().Where(x => x.IdeaId == vm.Id).Sum(x => (int)x.VoteValue);

                result = new OperationResultVo<BrainstormIdeaViewModel>(vm);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<BrainstormIdeaViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo Remove(Guid id)
        {
            OperationResultVo result;

            try
            {
                // validate before

                brainstormIdeaRepository.Remove(id);

                unitOfWork.Commit();

                result = new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }

        public OperationResultVo<Guid> Save(BrainstormIdeaViewModel viewModel)
        {
            OperationResultVo<Guid> result;

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

                    this.gamificationDomainService.ProcessAction(viewModel.UserId, PlatformAction.IdeaSuggested);
                }
                else
                {
                    brainstormIdeaRepository.Update(model);
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


        public OperationResultListVo<BrainstormIdeaViewModel> GetAll(Guid userId)
        {
            OperationResultListVo<BrainstormIdeaViewModel> result;

            try
            {
                IQueryable<BrainstormIdea> allModels = brainstormIdeaRepository.GetAll();

                IQueryable<BrainstormVote> currentUserVotes = brainstormVoteRepository.GetByUserId(userId);

                IEnumerable<BrainstormIdeaViewModel> vms = mapper.Map<IEnumerable<BrainstormIdea>, IEnumerable<BrainstormIdeaViewModel>>(allModels);

                foreach (BrainstormIdeaViewModel item in vms)
                {
                    item.UserContentType = UserContentType.VotingItem;
                    item.VoteCount = brainstormVoteRepository.Count(x => x.IdeaId == item.Id);
                    item.Score = brainstormVoteRepository.GetAll().Where(x => x.IdeaId == item.Id).Sum(x => (int)x.VoteValue);
                    item.CurrentUserVote = currentUserVotes.FirstOrDefault(x => x.IdeaId == item.Id)?.VoteValue ?? VoteValue.Neutral;

                    item.CommentCount = brainstormCommentRepository.Count(x => x.IdeaId == item.Id);
                }

                vms = vms.OrderByDescending(x => x.Score).ThenByDescending(x => x.CreateDate);

                result = new OperationResultListVo<BrainstormIdeaViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<BrainstormIdeaViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<BrainstormIdeaViewModel> GetById(Guid userId, Guid id)
        {
            OperationResultVo<BrainstormIdeaViewModel> result;

            try
            {
                BrainstormIdea model = brainstormIdeaRepository.GetById(id);

                BrainstormIdeaViewModel vm = mapper.Map<BrainstormIdeaViewModel>(model);

                vm.UserContentType = UserContentType.VotingItem;
                vm.VoteCount = brainstormVoteRepository.Count(x => x.IdeaId == vm.Id);
                vm.Score = brainstormVoteRepository.GetAll().Where(x => x.IdeaId == vm.Id).Sum(x => (int)x.VoteValue);
                vm.CurrentUserVote = brainstormVoteRepository.GetAll().FirstOrDefault(x => x.UserId == userId && x.IdeaId == id)?.VoteValue ?? VoteValue.Neutral;


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

                result = new OperationResultVo<BrainstormIdeaViewModel>(vm);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<BrainstormIdeaViewModel>(ex.Message);
            }

            return result;
        }


        public OperationResultVo Vote(Guid userId, Guid ideaId, VoteValue vote)
        {
            OperationResultVo result;

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

                result = new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<Guid>(ex.Message);
            }

            return result;
        }

        public OperationResultVo Comment(UserContentCommentViewModel vm)
        {
            OperationResultVo result;

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

                result = new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<Guid>(ex.Message);
            }

            return result;
        }


        /// <summary>
        /// Get the most recent session of type
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public OperationResultVo<BrainstormSessionViewModel> GetSession(Guid userId, BrainstormSessionType type)
        {
            OperationResultVo<BrainstormSessionViewModel> result;

            try
            {
                BrainstormSession model = brainstormSessionRepository.GetAll().LastOrDefault(x => x.Type == type);

                BrainstormSessionViewModel vm = mapper.Map<BrainstormSessionViewModel>(model);

                result = new OperationResultVo<BrainstormSessionViewModel>(vm);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<BrainstormSessionViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultListVo<BrainstormSessionViewModel> GetSessions(Guid userId)
        {
            OperationResultListVo<BrainstormSessionViewModel> result;

            try
            {
                IQueryable<BrainstormSession> model = brainstormSessionRepository.GetAll();

                IQueryable<BrainstormSessionViewModel> vms = model.ProjectTo<BrainstormSessionViewModel>(mapper.ConfigurationProvider);

                vms = vms.OrderBy(x => x.Type).ThenBy(x => x.CreateDate);

                result = new OperationResultListVo<BrainstormSessionViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<BrainstormSessionViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<Guid> SaveSession(BrainstormSessionViewModel vm)
        {
            OperationResultVo<Guid> result;

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

                result = new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<Guid>(ex.Message);
            }

            return result;
        }

        public OperationResultListVo<BrainstormIdeaViewModel> GetAllBySessionId(Guid userId, Guid sessionId)
        {
            OperationResultListVo<BrainstormIdeaViewModel> result;

            try
            {
                IQueryable<BrainstormIdea> allModels = brainstormIdeaRepository.GetAll().Where(x => x.SessionId == sessionId);

                IQueryable<BrainstormVote> currentUserVotes = brainstormVoteRepository.GetByUserId(userId);

                IEnumerable<BrainstormIdeaViewModel> vms = mapper.Map<IEnumerable<BrainstormIdea>, IEnumerable<BrainstormIdeaViewModel>>(allModels);

                foreach (BrainstormIdeaViewModel item in vms)
                {
                    item.UserContentType = UserContentType.VotingItem;
                    item.VoteCount = brainstormVoteRepository.Count(x => x.IdeaId == item.Id);
                    item.Score = brainstormVoteRepository.GetAll().Where(x => x.IdeaId == item.Id).Sum(x => (int)x.VoteValue);
                    item.CurrentUserVote = currentUserVotes.FirstOrDefault(x => x.IdeaId == item.Id)?.VoteValue ?? VoteValue.Neutral;

                    item.CommentCount = brainstormCommentRepository.Count(x => x.IdeaId == item.Id);
                }

                vms = vms.OrderByDescending(x => x.Score).ThenByDescending(x => x.CreateDate);

                result = new OperationResultListVo<BrainstormIdeaViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<BrainstormIdeaViewModel>(ex.Message);
            }

            return result;
        }
    }
}
