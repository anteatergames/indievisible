using IndieVisible.Application.AutoMapper.Resolvers;
using IndieVisible.Application.ViewModels.Brainstorm;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.FeaturedContent;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.Gamification;
using IndieVisible.Application.ViewModels.Notification;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Application.ViewModels.UserPreferences;
using Profile = AutoMapper.Profile;

namespace IndieVisible.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region General
            CreateMap<FeaturedContentViewModel, Domain.Models.FeaturedContent>();

            CreateMap<UserPreferencesViewModel, Domain.Models.UserPreferences>()
                .ForMember(dest => dest.ContentLanguages, opt => opt.ResolveUsing<UserLanguagesToDomainResolver>());
            
            CreateMap<NotificationItemViewModel, Domain.Models.Notification>();
            #endregion
            
            #region Game
            CreateMap<GameViewModel, Domain.Models.Game>()
                    .ForMember(dest => dest.DeveloperName, opt => opt.MapFrom(src => src.AuthorName))
                    .ForMember(dest => dest.Platforms, opt => opt.ResolveUsing<GamePlatformToDomainResolver>());
            #endregion

            #region Profile
            CreateMap<ProfileViewModel, Domain.Models.UserProfile>();
            #endregion

            #region Content
            CreateMap<UserContentViewModel, Domain.Models.UserContent>();
            CreateMap<UserContentListItemViewModel, Domain.Models.UserContent>(); 
            #endregion

            #region Brainstorm
            CreateMap<BrainstormSessionViewModel, Domain.Models.BrainstormSession>();
            CreateMap<BrainstormIdeaViewModel, Domain.Models.BrainstormIdea>();
            CreateMap<BrainstormVoteViewModel, Domain.Models.BrainstormVote>();
            CreateMap<BrainstormCommentViewModel, Domain.Models.BrainstormComment>();
            #endregion

            #region Gamification
            CreateMap<UserBadgeViewModel, Domain.Models.UserBadge>(); 
            #endregion

            #region Interactions
            CreateMap<GameFollowViewModel, Domain.Models.GameFollow>();

            CreateMap<UserFollowViewModel, Domain.Models.UserFollow>();

            CreateMap<UserConnectionViewModel, Domain.Models.UserConnection>(); 
            #endregion
        }
    }
}
