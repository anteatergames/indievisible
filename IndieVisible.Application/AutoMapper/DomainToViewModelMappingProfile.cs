using AutoMapper;
using IndieVisible.Application.AutoMapper.Resolvers;
using IndieVisible.Application.ViewModels.Brainstorm;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.FeaturedContent;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.Gamification;
using IndieVisible.Application.ViewModels.Jobs;
using IndieVisible.Application.ViewModels.Search;
using IndieVisible.Application.ViewModels.Team;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System.Linq;

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

            #endregion General

            #region Game

            CreateMap<Game, GameViewModel>()
                    .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.DeveloperName))
                    .ForMember(dest => dest.Platforms, opt => opt.MapFrom<GamePlatformFromDomainResolver>());
            CreateMap<Game, GameListItemViewModel>();

            CreateMap<GameExternalLink, GameExternalLinkViewModel>();

            #endregion Game

            #region Profile

            CreateMap<UserProfile, ProfileViewModel>()
                    .ForMember(x => x.Counters, opt => opt.Ignore())
                    .ForMember(x => x.IndieXp, opt => opt.Ignore());

            CreateMap<UserProfileExternalLink, UserProfileExternalLinkViewModel>();

            #endregion Profile

            #region Content

            CreateMap<UserContent, UserContentViewModel>()
                .ForMember(x => x.Likes, opt => opt.MapFrom(x => x.Likes.Select(y => y.UserId)))
                .ForMember(x => x.LikeCount, opt => opt.MapFrom(x => x.Likes.Count));

            CreateMap<UserContentComment, UserContentCommentViewModel>();

            CreateMap<UserContent, UserContentToBeFeaturedViewModel>();

            #endregion Content

            #region Brainstorm

            CreateMap<BrainstormSession, BrainstormSessionViewModel>();
            CreateMap<BrainstormIdea, BrainstormIdeaViewModel>();
            CreateMap<BrainstormVote, BrainstormVoteViewModel>();
            CreateMap<BrainstormComment, BrainstormCommentViewModel>();

            #endregion Brainstorm

            #region Gamification

            CreateMap<UserBadge, UserBadgeViewModel>();
            CreateMap<Gamification, RankingViewModel>();
            CreateMap<GamificationLevel, GamificationLevelViewModel>();

            #endregion Gamification

            #region Interaction

            CreateMap<GameFollow, GameFollowViewModel>();
            CreateMap<UserFollow, UserFollowViewModel>();
            CreateMap<UserConnection, UserConnectionViewModel>();

            #endregion Interaction

            #region Search

            CreateMap<UserContentSearchVo, UserContentSearchViewModel>();

            #endregion Search

            #region Team

            CreateMap<Team, TeamViewModel>();
            CreateMap<TeamMember, TeamMemberViewModel>()
                    .ForMember(dest => dest.Works, opt => opt.MapFrom<TeamWorkFromDomainResolver>());

            CreateMap<UserProfile, ProfileSearchViewModel>();

            #endregion Team

            #region Jobs

            CreateMap<JobPosition, JobPositionViewModel>();
            CreateMap<JobApplicant, JobApplicantViewModel>();

            #endregion Jobs
        }
    }
}