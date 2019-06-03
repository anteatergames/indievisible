using AutoMapper;
using AutoMapper.QueryableExtensions;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.FeaturedContent;
using IndieVisible.Application.ViewModels.Home;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndieVisible.Application.Services
{
    public class FeaturedContentAppService : BaseAppService, IFeaturedContentAppService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFeaturedContentRepository _repository;
        private readonly IUserContentRepository _contentRepository;
        private readonly IUserContentLikeRepository _likeRepository;
        private readonly IUserContentCommentRepository _commentRepository;

        public Guid CurrentUserId { get; set; }

        public FeaturedContentAppService(IMapper mapper, IUnitOfWork unitOfWork, IFeaturedContentRepository repository, IUserContentRepository contentRepository, IUserContentLikeRepository likeRepository, IUserContentCommentRepository commentRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
            _contentRepository = contentRepository;
            _likeRepository = likeRepository;
            _commentRepository = commentRepository;
        }

        public OperationResultVo<int> Count()
        {
            OperationResultVo<int> result;

            try
            {
                int count = _repository.GetAll().Count();

                result = new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<int>(ex.Message);
            }

            return result;
        }

        public OperationResultListVo<FeaturedContentViewModel> GetAll()
        {
            OperationResultListVo<FeaturedContentViewModel> result;

            try
            {
                IQueryable<FeaturedContent> allModels = _repository.GetAll();

                IEnumerable<FeaturedContentViewModel> vms = _mapper.Map<IEnumerable<FeaturedContent>, IEnumerable<FeaturedContentViewModel>>(allModels);

                result = new OperationResultListVo<FeaturedContentViewModel>(vms);
            }
            catch (Exception ex)
            {
                result = new OperationResultListVo<FeaturedContentViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo<FeaturedContentViewModel> GetById(Guid id)
        {
            OperationResultVo<FeaturedContentViewModel> result;

            try
            {
                FeaturedContent model = _repository.GetById(id);

                FeaturedContentViewModel vm = _mapper.Map<FeaturedContentViewModel>(model);

                result = new OperationResultVo<FeaturedContentViewModel>(vm);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<FeaturedContentViewModel>(ex.Message);
            }

            return result;
        }

        public OperationResultVo Remove(Guid id)
        {
            OperationResultVo result;

            try
            {
                // validate before

                _repository.Remove(id);

                _unitOfWork.Commit();

                result = new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo(ex.Message);
            }

            return result;
        }

        public OperationResultVo<Guid> Save(FeaturedContentViewModel viewModel)
        {
            OperationResultVo<Guid> result;

            try
            {
                FeaturedContent model;

                // TODO validate before

                FeaturedContent existing = _repository.GetById(viewModel.Id);

                if (existing != null)
                {
                    model = _mapper.Map(viewModel, existing);
                }
                else
                {
                    model = _mapper.Map<FeaturedContent>(viewModel);
                }

                if (viewModel.Id == Guid.Empty)
                {
                    _repository.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    _repository.Update(model);
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


        public CarouselViewModel GetFeaturedNow()
        {
            IQueryable<FeaturedContent> allModels = _repository.GetAll()
                .Where(x => x.StartDate.Date <= DateTime.Today && (x.EndDate.Date == DateTime.MinValue || x.EndDate.Date > DateTime.Today));

            if (allModels.Any())
            {
                IEnumerable<FeaturedContentViewModel> vms = _mapper.Map<IEnumerable<FeaturedContent>, IEnumerable<FeaturedContentViewModel>>(allModels);

                CarouselViewModel model = new CarouselViewModel();

                model.Items = vms.ToList();

                return model;
            }
            else
            {
                CarouselViewModel fake = FakeData.FakeCarousel();

                return fake;
            }
        }

        public OperationResultVo<Guid> Add(Guid userId, Guid contentId, string title, string introduction)
        {
            OperationResultVo<Guid> result;

            try
            {
                FeaturedContent newFeaturedContent = new FeaturedContent();
                newFeaturedContent.UserContentId = contentId;

                UserContent content = _contentRepository.GetById(contentId);

                newFeaturedContent.Title = string.IsNullOrWhiteSpace(title) ? content.Title : title;
                newFeaturedContent.Introduction = string.IsNullOrWhiteSpace(introduction) ? content.Introduction : introduction;

                newFeaturedContent.ImageUrl = string.IsNullOrWhiteSpace(content.FeaturedImage) || content.FeaturedImage.Equals(Constants.DefaultFeaturedImage) ? Constants.DefaultFeaturedImage : UrlFormatter.Image(content.UserId, BlobType.FeaturedImage, content.FeaturedImage);

                newFeaturedContent.StartDate = DateTime.Now;
                newFeaturedContent.Active = true;
                newFeaturedContent.UserId = userId;

                _repository.Add(newFeaturedContent);

                _unitOfWork.Commit();

                result = new OperationResultVo<Guid>(newFeaturedContent.Id);
            }
            catch (Exception ex)
            {
                result = new OperationResultVo<Guid>(ex.Message);
            }

            return result;
        }

        public IEnumerable<UserContentToBeFeaturedViewModel> GetContentToBeFeatured()
        {
            IQueryable<UserContent> finalList = _contentRepository.GetAll();

            List<UserContentToBeFeaturedViewModel> viewModels = finalList.ProjectTo<UserContentToBeFeaturedViewModel>(_mapper.ConfigurationProvider).ToList();

            foreach (UserContentToBeFeaturedViewModel item in viewModels)
            {
                FeaturedContent featuredNow = _repository.GetAll().FirstOrDefault(x => x.UserContentId == item.Id && x.StartDate.Date <= DateTime.Today && (x.EndDate.Date == null || x.EndDate.Date == DateTime.MinValue || x.EndDate.Date > DateTime.Today));

                if (featuredNow != null)
                {
                    item.CurrentFeatureId = featuredNow.Id;
                }


                item.IsFeatured = item.CurrentFeatureId.HasValue;

                item.AuthorName = string.IsNullOrWhiteSpace(item.AuthorName) ? "Unknown soul" : item.AuthorName;

                item.TitleCompliant = !string.IsNullOrWhiteSpace(item.Title) && item.Title.Length <= 25;

                item.IntroCompliant = !string.IsNullOrWhiteSpace(item.Introduction) && item.Introduction.Length <= 55;

                item.ContentCompliant = !string.IsNullOrWhiteSpace(item.Content) && item.Content.Length >= 800;

                item.IsArticle = !string.IsNullOrWhiteSpace(item.Title) && !string.IsNullOrWhiteSpace(item.Introduction);


                item.LikeCount = _likeRepository.GetAll().Count(x => x.ContentId == item.Id);

                item.CommentCount = _commentRepository.GetAll().Count(x => x.UserContentId == item.Id);
            }

            viewModels = viewModels.OrderByDescending(x => x.IsFeatured).ToList();

            return viewModels;
        }


        public OperationResultVo Unfeature(Guid id)
        {
            OperationResultVo result;

            try
            {

                // TODO validate before

                FeaturedContent existing = _repository.GetById(id);

                if (existing != null)
                {
                    existing.EndDate = DateTime.Now;

                    existing.Active = false;

                    _unitOfWork.Commit();
                }

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
