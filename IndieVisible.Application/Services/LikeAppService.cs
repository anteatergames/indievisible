using AutoMapper;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.UserLike;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class LikeAppService : BaseAppService, ILikeAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContentLikeRepository _contentLikeRepository;
        private readonly IGameLikeRepository _gameLikeRepository;

        public LikeAppService(IMapper mapper, IUnitOfWork unitOfWork
            , IUserContentLikeRepository contentLikeRepository, IGameLikeRepository gameLikeRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _contentLikeRepository = contentLikeRepository;
            _gameLikeRepository = gameLikeRepository;
        }

        public OperationResultVo<int> Count()
        {
            OperationResultVo<int> result;

            try
            {
                int count = _contentLikeRepository.GetAll().Count();

                result = new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<int>(ex.Message);
            }

            return result;
        }

        public OperationResultListVo<UserLikeViewModel> GetAll()
        {
            OperationResultListVo<UserLikeViewModel> result;

            try
            {
                IQueryable<UserContentLike> allModels = _contentLikeRepository.GetAll();

                IEnumerable<UserLikeViewModel> vms = _mapper.Map<IEnumerable<UserContentLike>, IEnumerable<UserLikeViewModel>>(allModels);

                result = new OperationResultListVo<UserLikeViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<UserLikeViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<UserLikeViewModel> GetById(Guid id)
        {
            OperationResultVo<UserLikeViewModel> result;

            try
            {
                UserContentLike model = _contentLikeRepository.GetById(id);

                UserLikeViewModel vm = _mapper.Map<UserLikeViewModel>(model);

                result = new OperationResultVo<UserLikeViewModel>(vm);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<UserLikeViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo Remove(Guid id)
        {
            OperationResultVo result;

            try
            {
                // validate before

                _contentLikeRepository.Remove(id);

                _unitOfWork.Commit();

                result = new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }

        public OperationResultVo<Guid> Save(UserLikeViewModel viewModel)
        {
            OperationResultVo<Guid> result;

            try
            {
                UserContentLike model;

                UserContentLike existing = _contentLikeRepository.GetById(viewModel.Id);
                if (existing != null)
                {
                    model = _mapper.Map(viewModel, existing);
                }
                else
                {
                    model = _mapper.Map<UserContentLike>(viewModel);
                }

                if (viewModel.Id == Guid.Empty)
                {
                    _contentLikeRepository.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    _contentLikeRepository.Update(model);
                }

                _unitOfWork.Commit();

                result = new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<Guid>(ex.Message);
            }

            return result;
        }

        public OperationResultVo ContentLike(Guid likedId)
        {
            OperationResultVo response;

            bool alreadyLiked = _contentLikeRepository.GetAll().Any(x => x.ContentId == likedId && x.UserId == this.CurrentUserId);

            if (alreadyLiked)
            {
                response = new OperationResultVo(false);
                response.Message = "Content already liked";
            }
            else
            {
                UserContentLike model = new UserContentLike();

                model.ContentId = likedId;
                model.UserId = this.CurrentUserId;

                _contentLikeRepository.Add(model);

                _unitOfWork.Commit();

                int newCount = _contentLikeRepository.GetAll().Count(x => x.ContentId == likedId && x.UserId == this.CurrentUserId);

                response = new OperationResultVo<int>(newCount);
            }

            return response;
        }

        public OperationResultVo ContentUnlike(Guid likedId)
        {
            OperationResultVo response;

            UserContentLike existingLike = _contentLikeRepository.GetAll().FirstOrDefault(x => x.ContentId == likedId && x.UserId == this.CurrentUserId);

            if (existingLike == null)
            {
                response = new OperationResultVo(false);
                response.Message = "Content not liked";
            }
            else
            {
                this.Remove(existingLike.Id);

                _unitOfWork.Commit();

                int newCount = _contentLikeRepository.GetAll().Count(x => x.ContentId == likedId && x.UserId == this.CurrentUserId);

                response = new OperationResultVo<int>(newCount);
            }

            return response;
        }

        public OperationResultVo GameLike(Guid gameId)
        {
            OperationResultVo response;

            if (this.CurrentUserId == Guid.Empty)
            {
                response = new OperationResultVo("You must be logged in to like a game");
            }
            else
            {
                bool alreadyLiked = _gameLikeRepository.GetAll().Any(x => x.GameId == gameId && x.UserId == this.CurrentUserId);

                if (alreadyLiked)
                {
                    response = new OperationResultVo(false);
                    response.Message = "Game already liked";
                }
                else
                {
                    GameLike model = new GameLike();

                    model.GameId = gameId;
                    model.UserId = this.CurrentUserId;

                    _gameLikeRepository.Add(model);

                    _unitOfWork.Commit();

                    int newCount = _gameLikeRepository.GetAll().Count(x => x.GameId == gameId && x.UserId == this.CurrentUserId);

                    response = new OperationResultVo<int>(newCount);
                }
            }

            return response;
        }

        public OperationResultVo GameUnlike(Guid likedId)
        {
            OperationResultVo response;

            if (this.CurrentUserId == Guid.Empty)
            {
                response = new OperationResultVo("You must be logged in to unlike a game");
            }
            else
            {

                GameLike existingLike = _gameLikeRepository.GetAll().FirstOrDefault(x => x.GameId == likedId && x.UserId == this.CurrentUserId);

                if (existingLike == null)
                {
                    response = new OperationResultVo(false);
                    response.Message = "Game not liked";
                }
                else
                {
                    this.RemoveGameLike(existingLike.Id);

                    _unitOfWork.Commit();

                    int newCount = _gameLikeRepository.GetAll().Count(x => x.GameId == likedId && x.UserId == this.CurrentUserId);

                    response = new OperationResultVo<int>(newCount);
                }
            }

            return response;
        }

        private OperationResultVo RemoveGameLike(Guid id)
        {
            OperationResultVo result;

            try
            {
                // validate before

                _gameLikeRepository.Remove(id);

                _unitOfWork.Commit();

                result = new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }
    }
}
