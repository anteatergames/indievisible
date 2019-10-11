using IndieVisible.Application;
using IndieVisible.Application.Formatters;
using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Domain.Core.Attributes;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Extensions;
using IndieVisible.Infra.CrossCutting.Identity.Models;
using IndieVisible.Web.Enums;
using IndieVisible.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IndieVisible.Web.Controllers.Base
{
    public class SecureBaseController : BaseController
    {
        private UserManager<ApplicationUser> _userManager;
        public UserManager<ApplicationUser> UserManager => _userManager ?? (_userManager = HttpContext?.RequestServices.GetService<UserManager<ApplicationUser>>());


        private IImageStorageService _imageStorageService;
        public IImageStorageService ImageStorageService => _imageStorageService ?? (_imageStorageService = HttpContext?.RequestServices.GetService<IImageStorageService>());


        private ICookieMgrService _cookieMgrService;
        public ICookieMgrService CookieMgrService => _cookieMgrService ?? (_cookieMgrService = HttpContext?.RequestServices.GetService<ICookieMgrService>());


        private IProfileAppService profileAppService;
        public IProfileAppService ProfileAppService => profileAppService ?? (profileAppService = HttpContext?.RequestServices.GetService<IProfileAppService>());


        public Guid CurrentUserId { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (User != null && User.Identity.IsAuthenticated && ViewBag.Username == null)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                CurrentUserId = new Guid(userId);

                string username = User.FindFirstValue(ClaimTypes.Name);

                SetProfileOnSession(CurrentUserId, username);

                ViewBag.CurrentUserId = CurrentUserId;
                ViewBag.Username = username ?? Constants.DefaultUsername;
                ViewBag.ProfileImage = UrlFormatter.ProfileImage(CurrentUserId);
            }
        }

        protected void SetProfileOnSession(Guid userId, string userName)
        {
            string sessionUserName = GetSessionValue(SessionValues.Username);

            if (sessionUserName != null && !sessionUserName.Equals(userName))
            {
                SetSessionValue(SessionValues.Username, userName);
            }

            string sessionFullName = GetSessionValue(SessionValues.FullName);

            if (sessionFullName == null)
            {
                ProfileViewModel profile = ProfileAppService.GetByUserId(userId, ProfileType.Personal);
                if (profile != null)
                {
                    SetSessionValue(SessionValues.FullName, profile.Name);
                }
            }
        }

        protected string GetAvatar()
        {
            return GetCookieValue(SessionValues.UserProfileImageUrl);
        }

        protected void SetAvatar(string profileImageUrl)
        {
            SetCookieValue(SessionValues.UserProfileImageUrl, profileImageUrl, 7, true);
        }


        protected ProfileViewModel SetAuthorDetails(UserGeneratedBaseViewModel vm)
        {
            if (vm.Id == Guid.Empty || vm.UserId == Guid.Empty)
            {
                vm.UserId = CurrentUserId;
            }

            ProfileViewModel profile = ProfileAppService.GetByUserId(CurrentUserId, vm.UserId, ProfileType.Personal);

            if (profile != null)
            {
                vm.AuthorName = profile.Name;
                vm.AuthorPicture = UrlFormatter.ProfileImage(vm.UserId);
            }

            return profile;
        }

        protected SupportedLanguage SetLanguageFromCulture(string languageCode)
        {
            switch (languageCode)
            {
                case "pt-BR":
                case "pt":
                    return SupportedLanguage.Portuguese;
                case "ru":
                case "ru-RU":
                    return SupportedLanguage.Russian;
                case "de":
                    return SupportedLanguage.German;
                case "es":
                    return SupportedLanguage.Spanish;
                case "bs":
                    return SupportedLanguage.Bosnian;
                case "sr":
                    return SupportedLanguage.Serbian;
                case "hr":
                    return SupportedLanguage.Croatian;
                default:
                    return SupportedLanguage.English;
            }
        }

        protected void SetLanguage(SupportedLanguage language)
        {
            string culture = language.GetAttributeOfType<UiInfoAttribute>()?.Culture;

            culture = string.IsNullOrWhiteSpace(culture) ? "en-US" : culture;

            SetCookieValue(CookieRequestCultureProvider.DefaultCookieName
                , CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture))
                , 365);
        }


        #region Upload Management
        #region Main Methods
        private string UploadImage(Guid userId, string imageType, string filename, byte[] fileBytes)
        {
            Task<string> op = ImageStorageService.StoreImageAsync(userId.ToString(), imageType.ToLower() + "_" + filename, fileBytes);
            op.Wait();

            if (!op.IsCompletedSuccessfully)
            {
                throw op.Exception;
            }

            string url = op.Result;

            return url;
        }
        private string DeleteImage(Guid userId, string filename)
        {
            Task<string> op = ImageStorageService.DeleteImageAsync(userId.ToString(), filename);
            op.Wait();

            if (!op.IsCompletedSuccessfully)
            {
                throw op.Exception;
            }

            string url = op.Result;

            return url;
        }

        private string DeleteImage(Guid userId, string imageType, string filename)
        {
            Task<string> op = ImageStorageService.DeleteImageAsync(userId.ToString(), imageType.ToLower() + "_" + filename);
            op.Wait();

            if (!op.IsCompletedSuccessfully)
            {
                throw op.Exception;
            }

            string url = op.Result;

            return url;
        }
        #endregion


        protected string UploadImage(Guid userId, BlobType container, string filename, byte[] fileBytes)
        {
            string containerName = container.ToString().ToLower();

            return UploadImage(userId, containerName, filename, fileBytes);
        }

        protected string UploadGameImage(Guid userId, BlobType type, string filename, byte[] fileBytes)
        {
            string result = UploadImage(userId, type.ToString().ToLower(), filename, fileBytes);

            return result;
        }

        protected string UploadContentImage(Guid userId, string filename, byte[] fileBytes)
        {
            string type = BlobType.ContentImage.ToString().ToLower();
            string result = UploadImage(userId, type, filename, fileBytes);

            return result;
        }

        protected string UploadFeaturedImage(Guid userId, string filename, byte[] fileBytes)
        {
            string type = BlobType.FeaturedImage.ToString().ToLower();
            string result = UploadImage(userId, type, filename, fileBytes);

            return result;
        }

        protected string DeleteGameImage(Guid userId, BlobType type, string filename)
        {
            string result = DeleteImage(userId, filename);

            return result;
        }

        protected string DeleteFeaturedImage(Guid userId, string filename)
        {
            string result = DeleteImage(userId, filename);

            return result;
        }
        #endregion


        #region Cookie Management
        protected string GetCookieValue(SessionValues key)
        {
            string value = CookieMgrService.Get(key.ToString());

            return value;
        }

        protected void SetCookieValue(SessionValues key, string value, int? expireTime)
        {
            SetCookieValue(key, value, expireTime, false);
        }
        protected void SetCookieValue(SessionValues key, string value, int? expireTime, bool isEssential)
        {
            CookieMgrService.Set(key.ToString(), value, expireTime, isEssential);
        }
        protected void SetCookieValue(string key, string value, int? expireTime)
        {
            SetCookieValue(key, value, expireTime, false);
        }
        protected void SetCookieValue(string key, string value, int? expireTime, bool isEssential)
        {
            CookieMgrService.Set(key, value, expireTime, isEssential);
        }
        #endregion
    }
}