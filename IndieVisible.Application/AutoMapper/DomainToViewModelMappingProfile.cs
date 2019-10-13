using AutoMapper;
using IndieVisible.Application.AutoMapper.Resolvers;
using IndieVisible.Application.ViewModels.Brainstorm;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.FeaturedContent;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.Gamification;
using IndieVisible.Application.ViewModels.Search;
using IndieVisible.Application.ViewModels.Team;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;

namespace IndieVisible.Application.AutoMapper
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            #region General
            CreateMap<Game, SelectListItemVo>()
                    .ForMember(x => x.Value, opt => opt.MapFrom(x => x.Id.ToString()))
                    .ForMember(x => x.Text, opt => opt.MapFrom(x => x.Title));

            CreateMap<FeaturedContent, FeaturedContentViewModel>();

            CreateMap<UserPreferences, UserPreferencesViewModel>()
                .ForMember(dest => dest.Languages, opt => opt.MapFrom<UserLanguagesFromDomainResolver>());
            #endregion

            #region Game
            CreateMap<Game, GameViewModel>()
                    .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.DeveloperName))
                    .ForMember(dest => dest.Platforms, opt => opt.MapFrom<GamePlatformFromDomainResolver>());
            CreateMap<Game, GameListItemViewModel>();

            CreateMap<GameExternalLink, GameExternalLinkViewModel>();
            #endregion

            #region Profile
            CreateMap<UserProfile, ProfileViewModel>()
                    .ForMember(x => x.Counters, opt => opt.Ignore())
                    .ForMember(x => x.IndieXp, opt => opt.Ignore());

            CreateMap<UserProfileExternalLink, UserProfileExternalLinkViewModel>();
            #endregion

            #region Content
            CreateMap<UserContent, UserContentViewModel>();
            CreateMap<UserContent, UserContentListItemViewModel>()
                .ForMember(x => x.LikeCount, opt => opt.MapFrom(x => x.Likes.Count));

            CreateMap<UserContentComment, UserContentCommentViewModel>();

            CreateMap<UserContent, UserContentToBeFeaturedViewModel>();
            #endregion

            #region Brainstorm
            CreateMap<BrainstormSession, BrainstormSessionViewModel>();
            CreateMap<BrainstormIdea, BrainstormIdeaViewModel>();
            CreateMap<BrainstormVote, BrainstormVoteViewModel>();
            CreateMap<BrainstormComment, BrainstormCommentViewModel>();
            #endregion

            #region Gamification
            CreateMap<UserBadge, UserBadgeViewModel>();
            CreateMap<Gamification, RankingViewModel>();
            CreateMap<GamificationLevel, GamificationLevelViewModel>();
            #endregion

            #region Interaction
            CreateMap<GameFollow, GameFollowViewModel>();
            CreateMap<UserFollow, UserFollowViewModel>();
            CreateMap<UserConnection, UserConnectionViewModel>();
            #endregion

            #region Search
            CreateMap<UserContentSearchVo, UserContentSearchViewModel>();
            #endregion

            #region Team
            CreateMap<Team, TeamViewModel>();
            CreateMap<TeamMember, TeamMemberViewModel>()
                    .ForMember(dest => dest.Works, opt => opt.MapFrom<TeamWorkFromDomainResolver>());

            CreateMap<UserProfile, ProfileSearchViewModel>();
            #endregion
        }
    }
}
