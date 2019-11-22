using IndieVisible.Application.Interfaces;
using IndieVisible.Application.Services;
using IndieVisible.Domain.Interfaces.Infrastructure;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Services;
using IndieVisible.Infra.CrossCutting.Identity.Services;
using IndieVisible.Infra.Data.Cache;
using IndieVisible.Infra.Data.MongoDb.Context;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
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
            services.AddScoped<IGameRepository, GameRepository>();
            #endregion

            #region Profile
            services.AddScoped<IProfileAppService, ProfileAppService>();
            services.AddScoped<IProfileDomainService, ProfileDomainService>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            #endregion

            #region Content
            services.AddScoped<IUserContentAppService, UserContentAppService>();
            services.AddScoped<IUserContentDomainService, UserContentDomainService>();
            services.AddScoped<IUserContentRepository, UserContentRepository>();
            #endregion

            #region Brainstorm
            services.AddScoped<IBrainstormAppService, BrainstormAppService>();
            services.AddScoped<IBrainstormRepository, BrainstormRepository>();
            #endregion

            #region Featuring
            services.AddScoped<IFeaturedContentAppService, FeaturedContentAppService>();
            services.AddScoped<IFeaturedContentRepository, FeaturedContentRepository>();
            #endregion

            #region Preferences
            services.AddScoped<IUserPreferencesAppService, UserPreferencesAppService>();
            services.AddScoped<IUserPreferencesRepository, UserPreferencesRepository>();
            #endregion

            #region Notifications
            services.AddScoped<INotificationAppService, NotificationAppService>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            #endregion

            #region Gamification
            services.AddScoped<IGamificationAppService, GamificationAppService>();
            services.AddScoped<IGamificationDomainService, GamificationDomainService>();
            services.AddScoped<IGamificationRepository, GamificationRepository>();
            services.AddScoped<IGamificationActionRepository, GamificationActionRepository>();
            services.AddScoped<IGamificationLevelRepository, GamificationLevelRepository>();
            services.AddScoped<IUserBadgeRepository, UserBadgeRepository>();
            #endregion

            #region Interactions
            services.AddScoped<IUserConnectionRepository, UserConnectionRepository>();
            #endregion

            #region Poll
            services.AddScoped<IPollAppService, PollAppService>();
            services.AddScoped<IPollDomainService, PollDomainService>();
            services.AddScoped<IPollRepository, PollRepository>();
            #endregion

            #region Team
            services.AddScoped<ITeamAppService, TeamAppService>();
            services.AddScoped<ITeamDomainService, TeamDomainService>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            #endregion

            // Infra - Identity Services
            services.AddTransient<IEmailSender, SendGridEmailService>();

            services.AddTransient<IImageStorageService, ImageStorageService>();

            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
