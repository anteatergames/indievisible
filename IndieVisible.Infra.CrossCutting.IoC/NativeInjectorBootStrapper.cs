using IndieVisible.Application.Interfaces;
using IndieVisible.Application.Services;
using IndieVisible.Domain.Interfaces;
using IndieVisible.Domain.Interfaces.Infrastructure;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Services;
using IndieVisible.Infra.CrossCutting.Abstractions;
using IndieVisible.Infra.CrossCutting.Notifications;
using IndieVisible.Infra.Data.Cache;
using IndieVisible.Infra.Data.MongoDb.Context;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Repository;
using IndieVisible.Infra.Data.MongoDb.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IndieVisible.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICacheService, CacheService>();

            #region Game

            services.AddScoped<IGameAppService, GameAppService>();
            services.AddScoped<IGameDomainService, GameDomainService>();
            services.AddScoped<IGameRepository, GameRepository>();

            #endregion Game

            #region Profile

            services.AddScoped<IProfileAppService, ProfileAppService>();
            services.AddScoped<IProfileDomainService, ProfileDomainService>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();

            #endregion Profile

            #region Content

            services.AddScoped<IUserContentAppService, UserContentAppService>();
            services.AddScoped<IUserContentDomainService, UserContentDomainService>();
            services.AddScoped<IUserContentRepository, UserContentRepository>();

            #endregion Content

            #region Brainstorm

            services.AddScoped<IBrainstormAppService, BrainstormAppService>();
            services.AddScoped<IBrainstormDomainService, BrainstormDomainService>();
            services.AddScoped<IBrainstormRepository, BrainstormRepository>();

            #endregion Brainstorm

            #region Featuring

            services.AddScoped<IFeaturedContentAppService, FeaturedContentAppService>();
            services.AddScoped<IFeaturedContentDomainService, FeaturedContentDomainService>();
            services.AddScoped<IFeaturedContentRepository, FeaturedContentRepository>();

            #endregion Featuring

            #region Preferences

            services.AddScoped<IUserPreferencesAppService, UserPreferencesAppService>();
            services.AddScoped<IUserPreferencesDomainService, UserPreferencesDomainService>();
            services.AddScoped<IUserPreferencesRepository, UserPreferencesRepository>();

            #endregion Preferences

            #region Notifications

            services.AddScoped<INotificationAppService, NotificationAppService>();
            services.AddScoped<INotificationDomainService, NotificationDomainService>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            #endregion Notifications

            #region Gamification

            services.AddScoped<IGamificationAppService, GamificationAppService>();
            services.AddScoped<IGamificationDomainService, GamificationDomainService>();
            services.AddScoped<IGamificationRepository, GamificationRepository>();
            services.AddScoped<IGamificationActionRepository, GamificationActionRepository>();
            services.AddScoped<IGamificationLevelRepository, GamificationLevelRepository>();
            services.AddScoped<IUserBadgeRepository, UserBadgeRepository>();

            #endregion Gamification

            #region Interactions

            services.AddScoped<IUserConnectionRepository, UserConnectionRepository>();

            #endregion Interactions

            #region Poll

            services.AddScoped<IPollAppService, PollAppService>();
            services.AddScoped<IPollDomainService, PollDomainService>();
            services.AddScoped<IPollRepository, PollRepository>();

            #endregion Poll

            #region Team

            services.AddScoped<ITeamAppService, TeamAppService>();
            services.AddScoped<ITeamDomainService, TeamDomainService>();
            services.AddScoped<ITeamRepository, TeamRepository>();

            #endregion Team

            #region Jobs

            services.AddScoped<IJobPositionAppService, JobPositionAppService>();
            services.AddScoped<IJobPositionDomainService, JobPositionDomainService>();
            services.AddScoped<IJobPositionRepository, JobPositionRepository>();

            #endregion Jobs

            #region Translations

            services.AddScoped<ILocalizationAppService, LocalizationAppService>();
            services.AddScoped<ILocalizationDomainService, TranslationDomainService>();
            services.AddScoped<ILocalizationRepository, TranslationRepository>();

            #endregion Translations

            // Infra
            services.AddTransient<INotificationSender, SendGridSlackNotificationService>();

            services.AddTransient<IImageStorageService, CloudinaryService>();

            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}