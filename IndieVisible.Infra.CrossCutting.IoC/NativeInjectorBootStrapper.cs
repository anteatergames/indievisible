using IndieVisible.Application.Interfaces;
using IndieVisible.Application.Services;
using IndieVisible.Domain.Interfaces.Base;
using IndieVisible.Domain.Interfaces.Repository;
using IndieVisible.Domain.Interfaces.Service;
using IndieVisible.Domain.Services;
using IndieVisible.Infra.CrossCutting.Identity.Services;
using IndieVisible.Infra.Data.Context;
using IndieVisible.Infra.Data.Repository;
using IndieVisible.Infra.Data.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IndieVisible.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            //services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            #region Game
            services.AddScoped<IGameAppService, GameAppService>();
            services.AddScoped<IGameRepository, GameRepository>();
            #endregion

            #region Profile
            services.AddScoped<IProfileAppService, ProfileAppService>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            #endregion

            #region Content
            services.AddScoped<IUserContentAppService, UserContentAppService>();
            services.AddScoped<IUserContentRepository, UserContentRepository>();
            #endregion

            #region Brainstorm
            services.AddScoped<IBrainstormAppService, BrainstormAppService>();
            services.AddScoped<IBrainstormSessionRepository, BrainstormSessionRepository>();
            services.AddScoped<IBrainstormIdeaRepository, BrainstormIdeaRepository>();
            services.AddScoped<IBrainstormVoteRepository, BrainstormVoteRepository>();
            services.AddScoped<IBrainstormCommentRepository, BrainstormCommentRepository>();
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
            services.AddScoped<IGamificationDomainService, GamificationDomainService>();
            services.AddScoped<IUserBadgeDomainService, UserBadgeDomainService>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            #endregion

            #region Gamification
            services.AddScoped<IUserBadgeAppService, UserBadgeAppService>();
            services.AddScoped<IGamificationRepository, GamificationRepository>();
            services.AddScoped<IGamificationActionRepository, GamificationActionRepository>();
            services.AddScoped<IGamificationLevelRepository, GamificationLevelRepository>();
            services.AddScoped<IUserBadgeRepository, UserBadgeRepository>();
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


            // Domain - Events
            //services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            //services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            //services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            //services.AddScoped<IRequestHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
            //services.AddScoped<IRequestHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            //services.AddScoped<IRequestHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<IndieVisibleContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, SendGridEmailService>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IImageStorageService, ImageStorageService>();
        }
    }
}
