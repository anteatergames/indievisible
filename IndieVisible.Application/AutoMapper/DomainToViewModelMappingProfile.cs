using AutoMapper;
using IndieVisible.Application.AutoMapper.Resolvers;
using IndieVisible.Application.ViewModels.Brainstorm;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.FeaturedContent;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.Gamification;
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
                .ForMember(dest => dest.Languages, opt => opt.ResolveUsing<UserLanguagesFromDomainResolver>());
            #endregion

            #region Game
            CreateMap<Game, GameViewModel>()
                    .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.DeveloperName))
                    .ForMember(dest => dest.Platforms, opt => opt.ResolveUsing<GamePlatformFromDomainResolver>());
            CreateMap<Game, GameListItemViewModel>();
            #endregion

            #region Profile
            CreateMap<UserProfile, ProfileViewModel>()
                    .ForMember(x => x.Counters, opt => opt.Ignore())
                    .ForMember(x => x.IndieXp, opt => opt.Ignore())
                    .ForMember(x => x.ExternalLinks, opt => opt.Ignore());
            #endregion

            #region Content
            CreateMap<UserContent, UserContentViewModel>();
            CreateMap<UserContent, UserContentListItemViewModel>()
                .ForMember(x => x.LikeCount, opt => opt.MapFrom(x => x.Likes.Count));

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
            #endregion

            #region Interaction
            CreateMap<GameFollow, GameFollowViewModel>();
            CreateMap<UserFollow, UserFollowViewModel>();
            CreateMap<UserConnection, UserConnectionViewModel>();
            #endregion
        }
    }
}
