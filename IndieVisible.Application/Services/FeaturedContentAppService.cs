using AutoMapper;
using AutoMapper.QueryableExtensions;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Helpers;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.FeaturedContent;
using IndieVisible.Application.ViewModels.Home;
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
    public class FeaturedContentAppService : BaseAppService, IFeaturedContentAppService
    {
        private readonly IFeaturedContentDomainService featuredContentDomainService;
        private readonly IUserContentDomainService userContentDomainService;

        public FeaturedContentAppService(IMapper mapper
            , IUnitOfWork unitOfWork
            , ICacheService cacheService
            , IFeaturedContentDomainService featuredContentDomainService
            , IUserContentDomainService userContentDomainService) : base(mapper, unitOfWork, cacheService)
        {
            this.featuredContentDomainService = featuredContentDomainService;
            this.userContentDomainService = userContentDomainService;
        }

        #region ICrudAppService

        public OperationResultVo<int> Count(Guid currentUserId)
        {
            try
            {
                int count = featuredContentDomainService.Count();

                return new OperationResultVo<int>(count);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<int>(ex.Message);
            }
        }

        public OperationResultListVo<FeaturedContentViewModel> GetAll(Guid currentUserId)
        {
            try
            {
                IEnumerable<FeaturedContent> allModels = featuredContentDomainService.GetAll();

                IEnumerable<FeaturedContentViewModel> vms = mapper.Map<IEnumerable<FeaturedContent>, IEnumerable<FeaturedContentViewModel>>(allModels);

                return new OperationResultListVo<FeaturedContentViewModel>(vms);
            }
            catch (Exception ex)
            {
                return new OperationResultListVo<FeaturedContentViewModel>(ex.Message);
            }
        }

        public OperationResultVo<FeaturedContentViewModel> GetById(Guid currentUserId, Guid id)
        {
            try
            {
                FeaturedContent model = featuredContentDomainService.GetById(id);

                FeaturedContentViewModel vm = mapper.Map<FeaturedContentViewModel>(model);

                return new OperationResultVo<FeaturedContentViewModel>(vm);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<FeaturedContentViewModel>(ex.Message);
            }
        }

        public OperationResultVo<Guid> Save(Guid currentUserId, FeaturedContentViewModel viewModel)
        {
            try
            {
                FeaturedContent model;

                FeaturedContent existing = featuredContentDomainService.GetById(viewModel.Id);

                if (existing != null)
                {
                    model = mapper.Map(viewModel, existing);
                }
                else
                {
                    model = mapper.Map<FeaturedContent>(viewModel);
                }

                if (viewModel.Id == Guid.Empty)
                {
                    featuredContentDomainService.Add(model);
                    viewModel.Id = model.Id;
                }
                else
                {
                    featuredContentDomainService.Update(model);
                }

                unitOfWork.Commit();

                return new OperationResultVo<Guid>(model.Id);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }

        public OperationResultVo Remove(Guid currentUserId, Guid id)
        {
            try
            {
                // validate before

                featuredContentDomainService.Remove(id);

                unitOfWork.Commit();

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        #endregion ICrudAppService

        public CarouselViewModel GetFeaturedNow()
        {
            IQueryable<FeaturedContent> allModels = featuredContentDomainService.GetFeaturedNow();

            if (allModels.Any())
            {
                IEnumerable<FeaturedContentViewModel> vms = allModels.ProjectTo<FeaturedContentViewModel>(mapper.ConfigurationProvider);

                CarouselViewModel model = new CarouselViewModel
                {
                    Items = vms.OrderByDescending(x => x.CreateDate).ToList()
                };

                foreach (FeaturedContentViewModel vm in model.Items)
                {
                    string[] imageSplit = vm.ImageUrl.Split("/");
                    Guid userId = vm.OriginalUserId == Guid.Empty ? vm.UserId : vm.OriginalUserId;

                    vm.FeaturedImage = ContentHelper.SetFeaturedImage(userId, imageSplit.Last(), ImageType.Full);
                    vm.FeaturedImageLquip = ContentHelper.SetFeaturedImage(userId, imageSplit.Last(), ImageType.LowQuality);
                }

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
            try
            {
                FeaturedContent newFeaturedContent = new FeaturedContent
                {
                    UserContentId = contentId
                };

                UserContent content = userContentDomainService.GetById(contentId);

                newFeaturedContent.Title = string.IsNullOrWhiteSpace(title) ? content.Title : title;
                newFeaturedContent.Introduction = string.IsNullOrWhiteSpace(introduction) ? content.Introduction : introduction;

                newFeaturedContent.ImageUrl = string.IsNullOrWhiteSpace(content.FeaturedImage) || content.FeaturedImage.Equals(Constants.DefaultFeaturedImage) ? Constants.DefaultFeaturedImage : UrlFormatter.Image(content.UserId, BlobType.FeaturedImage, content.FeaturedImage);

                newFeaturedContent.FeaturedImage = content.FeaturedImage;

                newFeaturedContent.StartDate = DateTime.Now;
                newFeaturedContent.Active = true;
                newFeaturedContent.UserId = userId;
                newFeaturedContent.OriginalUserId = content.UserId;

                featuredContentDomainService.Add(newFeaturedContent);

                unitOfWork.Commit();

                return new OperationResultVo<Guid>(newFeaturedContent.Id);
            }
            catch (Exception ex)
            {
                return new OperationResultVo<Guid>(ex.Message);
            }
        }

        public IEnumerable<UserContentToBeFeaturedViewModel> GetContentToBeFeatured()
        {
            IEnumerable<UserContent> finalList = userContentDomainService.GetAll();
            IEnumerable<FeaturedContent> featured = featuredContentDomainService.GetAll();

            IEnumerable<UserContentToBeFeaturedViewModel> vms = mapper.Map<IEnumerable<UserContent>, IEnumerable<UserContentToBeFeaturedViewModel>>(finalList);

            foreach (UserContentToBeFeaturedViewModel item in vms)
            {
                FeaturedContent featuredNow = featured.FirstOrDefault(x => x.UserContentId == item.Id && x.StartDate.Date <= DateTime.Today && (!x.EndDate.HasValue || (x.EndDate.HasValue && x.EndDate.Value.Date > DateTime.Today)));

                if (featuredNow != null)
                {
                    item.CurrentFeatureId = featuredNow.Id;
                }

                item.IsFeatured = item.CurrentFeatureId.HasValue;

                item.AuthorName = string.IsNullOrWhiteSpace(item.AuthorName) ? Constants.UnknownSoul : item.AuthorName;

                item.TitleCompliant = !string.IsNullOrWhiteSpace(item.Title) && item.Title.Length <= 25;

                item.IntroCompliant = !string.IsNullOrWhiteSpace(item.Introduction) && item.Introduction.Length <= 55;

                item.ContentCompliant = !string.IsNullOrWhiteSpace(item.Content) && item.Content.Length >= 800;

                item.IsArticle = !string.IsNullOrWhiteSpace(item.Title) && !string.IsNullOrWhiteSpace(item.Introduction);
            }

            vms = vms.OrderByDescending(x => x.IsFeatured).ToList();

            return vms;
        }

        public OperationResultVo Unfeature(Guid id)
        {
            try
            {
                FeaturedContent existing = featuredContentDomainService.GetById(id);

                if (existing != null)
                {
                    existing.EndDate = DateTime.Now;

                    existing.Active = false;

                    featuredContentDomainService.Update(existing);

                    unitOfWork.Commit();
                }

                return new OperationResultVo(true);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }
    }
}