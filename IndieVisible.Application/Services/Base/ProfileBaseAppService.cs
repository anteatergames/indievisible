using AutoMapper;
using CountryData;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Models;
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
    public abstract class ProfileBaseAppService : BaseAppService, IProfileBaseAppService
    {
        protected readonly IProfileDomainService profileDomainService;

        protected ProfileBaseAppService(IMapper mapper
            , IUnitOfWork unitOfWork
            , ICacheService cacheService
            , IProfileDomainService profileDomainService) : base(mapper, unitOfWork, cacheService)
        {
            this.profileDomainService = profileDomainService;
        }

        #region Profile

        public void SetProfileCache(Guid userId, UserProfile value)
        {
            cacheService.Set<string, UserProfile>(FormatProfileCacheId(userId), value);
        }

        public void SetProfileCache(Guid userId, ProfileViewModel viewModel)
        {
            UserProfile model = mapper.Map<UserProfile>(viewModel);

            SetProfileCache(viewModel.UserId, model);
        }

        private UserProfile GetProfileFromCache(Guid userId)
        {
            UserProfile fromCache = cacheService.Get<string, UserProfile>(FormatProfileCacheId(userId));

            return fromCache;
        }

        protected UserProfile GetCachedProfileByUserId(Guid userId)
        {
            UserProfile profile = GetProfileFromCache(userId);

            if (profile == null)
            {
                UserProfile profileFromDb = profileDomainService.GetByUserId(userId).FirstOrDefault();

                if (profileFromDb != null)
                {
                    SetProfileCache(userId, profileFromDb);
                    profile = profileFromDb;
                }
            }

            return profile;
        }

        public ProfileViewModel GetUserProfileWithCache(Guid userId)
        {
            UserProfile model = GetProfileFromCache(userId);

            if (model == null)
            {
                model = profileDomainService.GetByUserId(userId).FirstOrDefault();
            }

            ProfileViewModel viewModel = mapper.Map<ProfileViewModel>(model);

            return viewModel;
        }

        #endregion Profile

        #region Generics

        private void SetOjectOnCache<T>(Guid id, T value, string preffix)
        {
            cacheService.Set<string, T>(FormatObjectCacheId(preffix, id), value);
        }

        private T GetObjectFromCache<T>(Guid id, string preffix) where T : Entity
        {
            T fromCache = cacheService.Get<string, T>(FormatObjectCacheId(preffix, id));

            return fromCache;
        }

        private T GetCachedObjectById<T>(IDomainService<T> domainService, Guid id, string preffix) where T : Entity
        {
            T obj = GetObjectFromCache<T>(id, preffix);

            if (obj == null)
            {
                T objectFromDb = domainService.GetById(id);

                if (objectFromDb != null)
                {
                    SetOjectOnCache(id, objectFromDb, preffix);
                    obj = objectFromDb;
                }
            }

            return obj;
        }

        public OperationResultVo GetCountries(Guid currentUserId)
        {
            try
            {
                IEnumerable<SelectListItemVo> countries = CountryLoader.CountryInfo.Select(x => new SelectListItemVo(x.Name, x.Name)).OrderBy(x => x.Text);

                return new OperationResultListVo<SelectListItemVo>(countries);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        public OperationResultVo GetCities(Guid currentUserId, string country, string q)
        {
            try
            {
                var countryData = LoadCountryData(country);
                if (countryData == null)
                {
                    return new OperationResultVo("meh");
                }

                var community = countryData.Communities().FirstOrDefault();

                var cities = countryData.Communities().SelectMany(x => x.Places).Where(x => x.Name.ToLower().Contains(q.ToLower())).Select(x => new SelectListItemVo(String.Format("{0} ({1})", x.Name, x.PostCode), x.Name));

                return new OperationResultListVo<SelectListItemVo>(cities);
            }
            catch (Exception ex)
            {
                return new OperationResultVo(ex.Message);
            }
        }

        #endregion Generics

        #region Game

        public void SetGameCache(Guid id, Game value)
        {
            cacheService.Set<string, Game>(FormatObjectCacheId("game", id), value);
        }

        public void SetGameCache(Guid id, GameViewModel viewModel)
        {
            Game model = mapper.Map<Game>(viewModel);

            SetGameCache(id, model);
        }

        public GameViewModel GetGameWithCache(IDomainService<Game> domainService, Guid id)
        {
            Game model = GetObjectFromCache<Game>(id, "game");

            if (model == null)
            {
                model = domainService.GetById(id);
            }

            GameViewModel viewModel = mapper.Map<GameViewModel>(model);

            return viewModel;
        }

        #endregion Game

        private string FormatProfileCacheId(Guid userId)
        {
            return String.Format("profile_{0}", userId.ToString());
        }

        private string FormatObjectCacheId(string preffix, Guid id)
        {
            return String.Format("{0}_{1}", preffix, id.ToString());
        }

        private static ICountry LoadCountryData(string country)
        {
            switch (country)
            {
                case "Brazil":
                    return CountryLoader.LoadBrazilLocationData();
                case "United Kingdom":
                    return CountryLoader.LoadUnitedKingdomLocationData();
                case "United States":
                    return CountryLoader.LoadUnitedStatesLocationData();
                default:
                    return null;
            }
        }
    }
}