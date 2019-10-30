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
        private readonly IUnitOfWorkSql _unitOfWork;
        private readonly IUserContentLikeRepositorySql _contentLikeRepository;
        private readonly IGameLikeRepositorySql _gameLikeRepository;

        public LikeAppService(IMapper mapper, IUnitOfWorkSql unitOfWork
            , IUserContentLikeRepositorySql contentLikeRepository, IGameLikeRepositorySql gameLikeRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _contentLikeRepository = contentLikeRepository;
            _gameLikeRepository = gameLikeRepository;
        }

        #region ICrudAppService
        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = _contentLikeRepository.GetAll().Count();

                return new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<int>(ex.Message);
            }
        }

        public OperationResultListVo<UserLikeViewModel> GetAll(Guid currentUserId)
        {
            try
            {
                IQueryable<UserContentLike> allModels = _contentLikeRepository.GetAll();

                IEnumerable<UserLikeViewModel> vms = _mapper.Map<IEnumerable<UserContentLike>, IEnumerable<UserLikeViewModel>>(allModels);

                return new OperationResultListVo<UserLikeViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<UserLikeViewModel>(ex.Message);
            }
        }

        public OperationResultVo<UserLikeViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                UserContentLike model = _contentLikeRepository.GetById(id);

                UserLikeViewModel vm = _mapper.Map<UserLikeViewModel>(model);

                return new OperationResultVo<UserLikeViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<UserLikeViewModel>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            try
            {
                // validate before

                _contentLikeRepository.Remove(id);

                _unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, UserLikeViewModel viewModel)
        {
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

                return new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }
        #endregion

        public OperationResultVo ContentLike(Guid currentUserId, Guid likedId)
        {
            bool alreadyLiked = _contentLikeRepository.GetAll().Any(x => x.ContentId == likedId && x.UserId == currentUserId);

            if (alreadyLiked)
            {
                return new OperationResultVo("Content already liked");
            }
            else
            {
                UserContentLike model = new UserContentLike
                {
                    ContentId = likedId,
                    UserId = currentUserId
                };

                _contentLikeRepository.Add(model);

                _unitOfWork.Commit();

                int newCount = _contentLikeRepository.GetAll().Count(x => x.ContentId == likedId && x.UserId == currentUserId);

                return new OperationResultVo<int>(newCount);
            }
        }

        public OperationResultVo ContentUnlike(Guid currentUserId, Guid likedId)
        {
            UserContentLike existingLike = _contentLikeRepository.GetAll().FirstOrDefault(x => x.ContentId == likedId && x.UserId == currentUserId);

            if (existingLike == null)
            {
                return new OperationResultVo("Content not liked");
            }
            else
            {
                Remove(currentUserId, existingLike.Id);

                _unitOfWork.Commit();

                int newCount = _contentLikeRepository.GetAll().Count(x => x.ContentId == likedId && x.UserId == currentUserId);

                return new OperationResultVo<int>(newCount);
            }
        }

        public OperationResultVo GameLike(Guid currentUserId, Guid gameId)
        {
            if (currentUserId == Guid.Empty)
            {
                return new OperationResultVo("You must be logged in to like a game");
            }
            else
            {
                bool alreadyLiked = _gameLikeRepository.GetAll().Any(x => x.GameId == gameId && x.UserId == currentUserId);

                if (alreadyLiked)
                {
                    return new OperationResultVo("Game already liked");
                }
                else
                {
                    GameLike model = new GameLike
                    {
                        GameId = gameId,
                        UserId = currentUserId
                    };

                    _gameLikeRepository.Add(model);

                    _unitOfWork.Commit();

                    int newCount = _gameLikeRepository.GetAll().Count(x => x.GameId == gameId && x.UserId == currentUserId);

                    return new OperationResultVo<int>(newCount);
                }
            }
        }

        public OperationResultVo GameUnlike(Guid currentUserId, Guid likedId)
        {
            if (currentUserId == Guid.Empty)
            {
                return new OperationResultVo("You must be logged in to unlike a game");
            }
            else
            {

                GameLike existingLike = _gameLikeRepository.GetAll().FirstOrDefault(x => x.GameId == likedId && x.UserId == currentUserId);

                if (existingLike == null)
                {
                    return new OperationResultVo("Game not liked");
                }
                else
                {
                    OperationResultVo result = RemoveGameLike(existingLike.Id);

                    if (result.Success)
                    {
                        _unitOfWork.Commit();
                    }

                    int newCount = _gameLikeRepository.GetAll().Count(x => x.GameId == likedId && x.UserId == currentUserId);

                    return new OperationResultVo<int>(newCount);
                }
            }
        }

        private OperationResultVo RemoveGameLike(Guid id)
        {
            try
            {
                // validate before

                _gameLikeRepository.Remove(id);

                _unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }
    }
}
