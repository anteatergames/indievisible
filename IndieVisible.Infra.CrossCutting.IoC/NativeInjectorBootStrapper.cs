using IndieVisible.Application.Interfaces;
using IndieVisible.Application.Services;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Services;
using IndieVisible.Infra.CrossCutting.Identity.Services;
using IndieVisible.Infra.Data.Context;
using IndieVisible.Infra.Data.MongoDb.Context;
using IndieVisible.Infra.Data.MongoDb.Interfaces;
using IndieVisible.Infra.Data.MongoDb.Interfaces.Repository;
using IndieVisible.Infra.Data.MongoDb.Repository;
using IndieVisible.Infra.Data.MongoDb.UoW;
using IndieVisible.Infra.Data.Repository;
using IndieVisible.Infra.Data.UoW;
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

            #region Game
            services.AddScoped<IGameAppService, GameAppService>();
            services.AddScoped<IGameRepository, GameRepository>();

            services.AddScoped<IGameRepositorySql, GameRepositorySql>();
            #endregion

            #region Profile
            services.AddScoped<IProfileAppService, ProfileAppService>();
            services.AddScoped<IProfileDomainService, ProfileDomainService>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();

            services.AddScoped<IProfileRepositorySql, ProfileRepositorySql>();
            #endregion

            #region Content
            services.AddScoped<IUserContentAppService, UserContentAppService>();
            services.AddScoped<IUserContentDomainService, UserContentDomainService>();
            services.AddScoped<IUserContentRepository, UserContentRepository>();

            services.AddScoped<IUserContentRepositorySql, UserContentRepositorySql>();
            #endregion

            #region Brainstorm
            services.AddScoped<IBrainstormAppService, BrainstormAppService>();
            services.AddScoped<IBrainstormCommentRepositorySql, BrainstormCommentRepository>();
            services.AddScoped<IBrainstormRepository, BrainstormRepository>();

            services.AddScoped<IBrainstormSessionRepositorySql, BrainstormSessionRepositorySql>();
            services.AddScoped<IBrainstormIdeaRepositorySql, BrainstormIdeaRepositorySql>();
            services.AddScoped<IBrainstormVoteRepositorySql, BrainstormVoteRepositorySql>();
            #endregion

            #region Featuring
            services.AddScoped<IFeaturedContentAppService, FeaturedContentAppService>();
            services.AddScoped<IFeaturedContentRepository, FeaturedContentRepository>();

            services.AddScoped<IFeaturedContentRepositorySql, FeaturedContentRepositorySql>();
            #endregion

            #region Preferences
            services.AddScoped<IUserPreferencesAppService, UserPreferencesAppService>();
            services.AddScoped<IUserPreferencesRepository, UserPreferencesRepository>();

            services.AddScoped<IUserPreferencesRepositorySql, UserPreferencesRepositorySql>();
            #endregion

            #region Notifications
            services.AddScoped<INotificationAppService, NotificationAppService>();
            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddScoped<INotificationRepositorySql, NotificationRepositorySql>();
            #endregion

            #region Gamification
            services.AddScoped<IGamificationAppService, GamificationAppService>();
            services.AddScoped<IGamificationDomainService, GamificationDomainService>();
            services.AddScoped<IGamificationRepository, GamificationRepository>();
            services.AddScoped<IGamificationActionRepository, GamificationActionRepository>();
            services.AddScoped<IGamificationLevelRepository, GamificationLevelRepository>();
            services.AddScoped<IUserBadgeRepository, UserBadgeRepository>();

            services.AddScoped<IUserBadgeRepositorySql, UserBadgeRepositorySql>();
            services.AddScoped<IGamificationRepositorySql, GamificationRepositorySql>();
            services.AddScoped<IGamificationActionRepositorySql, GamificationActionRepositorySql>();
            services.AddScoped<IGamificationLevelRepositorySql, GamificationLevelRepositorySql>();
            #endregion

            #region Interactions
            services.AddScoped<IUserContentCommentAppService, UserContentCommentAppService>();

            services.AddScoped<IUserFollowAppService, UserFollowAppService>();
            services.AddScoped<IUserFollowDomainService, UserFollowDomainService>();

            services.AddScoped<IUserConnectionAppService, UserConnectionAppService>();
            services.AddScoped<IUserConnectionDomainService, UserConnectionDomainService>();
            services.AddScoped<IUserConnectionRepository, UserConnectionRepository>();

            services.AddScoped<IUserContentLikeRepositorySql, UserContentLikeRepositorySql>();
            services.AddScoped<IUserContentCommentRepositorySql, UserContentCommentRepositorySql>();
            services.AddScoped<IGameLikeRepositorySql, GameLikeRepositorySql>();
            services.AddScoped<IGameFollowRepositorySql, GameFollowRepositorySql>();
            services.AddScoped<IUserFollowRepositorySql, UserFollowRepositorySql>();
            #endregion

            #region Poll
            services.AddScoped<IPollAppService, PollAppService>();
            services.AddScoped<IPollDomainService, PollDomainService>();
            services.AddScoped<IPollRepository, PollRepository>();


            services.AddScoped<IPollRepositorySql, PollRepositorySql>();
            services.AddScoped<IPollOptionRepositorySql, PollOptionRepositorySql>();
            services.AddScoped<IPollVoteRepositorySql, PollVoteRepositorySql>();
            #endregion

            #region Team
            services.AddScoped<ITeamAppService, TeamAppService>();
            services.AddScoped<ITeamDomainService, TeamDomainService>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            #endregion

            // Infra - Data
            services.AddScoped<IndieVisibleContext>();
            services.AddScoped<IUnitOfWorkSql, UnitOfWorkSql>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, SendGridEmailService>();

            services.AddTransient<IImageStorageService, ImageStorageService>();

            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
