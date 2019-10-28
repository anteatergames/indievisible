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
            services.AddScoped<Domain.Interfaces.Repository.IGameRepository, Data.Repository.GameRepository>();
            services.AddScoped<Data.MongoDb.Interfaces.Repository.IGameRepository, Data.MongoDb.Repository.GameRepository>();
            #endregion

            #region Profile
            services.AddScoped<IProfileAppService, ProfileAppService>();
            services.AddScoped<IProfileDomainService, ProfileDomainService>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<Data.MongoDb.Interfaces.Repository.IUserProfileRepository, Data.MongoDb.Repository.UserProfileRepository>();
            #endregion

            #region Content
            services.AddScoped<IUserContentAppService, UserContentAppService>();
            services.AddScoped<IUserContentDomainService, UserContentDomainService>();
            services.AddScoped<Domain.Interfaces.Repository.IUserContentRepository, Data.Repository.UserContentRepository>();
            services.AddScoped<Data.MongoDb.Interfaces.Repository.IUserContentRepository, Data.MongoDb.Repository.UserContentRepository>();
            #endregion

            #region Brainstorm
            services.AddScoped<IBrainstormAppService, BrainstormAppService>();
            services.AddScoped<IBrainstormSessionRepository, BrainstormSessionRepository>();
            services.AddScoped<IBrainstormIdeaRepository, BrainstormIdeaRepository>();
            services.AddScoped<IBrainstormVoteRepository, BrainstormVoteRepository>();
            services.AddScoped<IBrainstormCommentRepository, BrainstormCommentRepository>();
            services.AddScoped<Data.MongoDb.Interfaces.Repository.IBrainstormRepository, Data.MongoDb.Repository.BrainstormRepository>();
            #endregion

            #region Featuring
            services.AddScoped<IFeaturedContentAppService, FeaturedContentAppService>();
            services.AddScoped<Domain.Interfaces.Repository.IFeaturedContentRepository, Data.Repository.FeaturedContentRepository>();
            services.AddScoped<Data.MongoDb.Interfaces.Repository.IFeaturedContentRepository, Data.MongoDb.Repository.FeaturedContentRepository>();
            #endregion

            #region Preferences
            services.AddScoped<IUserPreferencesAppService, UserPreferencesAppService>();
            services.AddScoped<Domain.Interfaces.Repository.IUserPreferencesRepository, Data.Repository.UserPreferencesRepository>();
            services.AddScoped<Data.MongoDb.Interfaces.Repository.IUserPreferencesRepository, Data.MongoDb.Repository.UserPreferencesRepository>();
            #endregion

            #region Notifications
            services.AddScoped<INotificationAppService, NotificationAppService>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            #endregion

            #region Gamification
            services.AddScoped<IUserBadgeAppService, UserBadgeAppService>();
            services.AddScoped<IUserBadgeDomainService, UserBadgeDomainService>();
            services.AddScoped<IUserBadgeRepository, UserBadgeRepository>();
            services.AddScoped<IGamificationAppService, GamificationAppService>();
            services.AddScoped<IGamificationDomainService, GamificationDomainService>();
            services.AddScoped<IGamificationRepository, GamificationRepository>();
            services.AddScoped<IGamificationActionRepository, GamificationActionRepository>();
            services.AddScoped<IGamificationLevelRepository, GamificationLevelRepository>();
            #endregion

            #region Interactions
            services.AddScoped<IUserContentCommentAppService, UserContentCommentAppService>();
            services.AddScoped<IUserContentCommentRepository, UserContentCommentRepository>();

            services.AddScoped<ILikeAppService, LikeAppService>();
            services.AddScoped<IUserContentLikeRepository, UserContentLikeRepository>();
            services.AddScoped<IGameLikeRepository, GameLikeRepository>();

            services.AddScoped<IFollowAppService, FollowAppService>();

            services.AddScoped<IGameFollowAppService, GameFollowAppService>();
            services.AddScoped<IGameFollowDomainService, GameFollowDomainService>();
            services.AddScoped<IGameFollowRepository, GameFollowRepository>();

            services.AddScoped<IUserFollowAppService, UserFollowAppService>();
            services.AddScoped<IUserFollowDomainService, UserFollowDomainService>();
            services.AddScoped<IUserFollowRepository, UserFollowRepository>();

            services.AddScoped<IUserConnectionAppService, UserConnectionAppService>();
            services.AddScoped<IUserConnectionDomainService, UserConnectionDomainService>();
            services.AddScoped<IUserConnectionRepository, UserConnectionRepository>();
            #endregion

            #region Poll
            services.AddScoped<IPollAppService, PollAppService>();
            services.AddScoped<IPollDomainService, PollDomainService>();
            services.AddScoped<IPollRepository, PollRepository>();
            services.AddScoped<IPollOptionRepository, PollOptionRepository>();
            services.AddScoped<IPollVoteRepository, PollVoteRepository>();
            #endregion

            #region Team
            services.AddScoped<ITeamAppService, TeamAppService>();
            services.AddScoped<ITeamDomainService, TeamDomainService>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            #endregion

            // Infra - Data
            services.AddScoped<IndieVisibleContext>();
            services.AddScoped<Domain.Interfaces.Base.IUnitOfWorkSql, IndieVisible.Infra.Data.UoW.UnitOfWork>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, SendGridEmailService>();

            services.AddTransient<IImageStorageService, ImageStorageService>();

            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<Data.MongoDb.Interfaces.IUnitOfWork, Data.MongoDb.UoW.UnitOfWork>();
        }
    }
}
