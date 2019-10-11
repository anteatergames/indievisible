using IndieVisible.Application.AutoMapper.MappingActions;
using IndieVisible.Application.AutoMapper.Resolvers;
using IndieVisible.Application.ViewModels.Brainstorm;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.FeaturedContent;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.Gamification;
using IndieVisible.Application.ViewModels.Notification;
using IndieVisible.Application.ViewModels.Team;
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
                .ForMember(dest => dest.ContentLanguages, opt => opt.MapFrom<UserLanguagesToDomainResolver>());

            CreateMap<NotificationItemViewModel, Domain.Models.Notification>();
            #endregion

            #region Game
            CreateMap<GameViewModel, Domain.Models.Game>()
                    .ForMember(dest => dest.DeveloperName, opt => opt.MapFrom(src => src.AuthorName))
                    .ForMember(dest => dest.Platforms, opt => opt.MapFrom<GamePlatformToDomainResolver>());
            #endregion

            #region Profile
            CreateMap<ProfileViewModel, Domain.Models.UserProfile>()
                .ForMember(dest => dest.ExternalLinks, opt => opt.Ignore())
                .AfterMap<AddOrUpdateExternalLinks>();

            CreateMap<UserProfileExternalLinkViewModel, Domain.Models.UserProfileExternalLink>();
            #endregion

            #region Content
            CreateMap<UserContentViewModel, Domain.Models.UserContent>();
            CreateMap<UserContentListItemViewModel, Domain.Models.UserContent>();

            CreateMap<UserContentCommentViewModel, Domain.Models.UserContentComment>();
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

            #region Team
            CreateMap<TeamViewModel, Domain.Models.Team>()
                .ForMember(dest => dest.Members, opt => opt.Ignore())
                .AfterMap<AddOrUpdateTeamMembers>();
            CreateMap<TeamMemberViewModel, Domain.Models.TeamMember>()
                    .ForMember(dest => dest.Work, opt => opt.MapFrom<TeamWorkToDomainResolver>());
            #endregion
        }
    }
}
