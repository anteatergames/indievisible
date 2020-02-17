using IndieVisible.Application.AutoMapper.MappingActions;
using IndieVisible.Application.AutoMapper.Resolvers;
using IndieVisible.Application.ViewModels;
using IndieVisible.Application.ViewModels.Brainstorm;
using IndieVisible.Application.ViewModels.Content;
using IndieVisible.Application.ViewModels.FeaturedContent;
using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Application.ViewModels.Gamification;
using IndieVisible.Application.ViewModels.Jobs;
using IndieVisible.Application.ViewModels.Notification;
using IndieVisible.Application.ViewModels.Team;
using IndieVisible.Application.ViewModels.User;
using IndieVisible.Application.ViewModels.UserPreferences;
using IndieVisible.Domain.Core.Models;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using Profile = AutoMapper.Profile;

namespace IndieVisible.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region General

            CreateMap<BaseViewModel, Entity>()
                .ForMember(dest => dest.CreateDate, opt => opt.Condition(x => x.CreateDate != DateTime.MinValue));

            CreateMap<FeaturedContentViewModel, Domain.Models.FeaturedContent>();

            CreateMap<UserPreferencesViewModel, Domain.Models.UserPreferences>()
                .ForMember(dest => dest.ContentLanguages, opt => opt.MapFrom<UserLanguagesToDomainResolver>());

            CreateMap<NotificationItemViewModel, Domain.Models.Notification>();

            CreateMap<ExternalLinkBaseViewModel, ExternalLinkVo>();

            CreateMap<CommentViewModel, Domain.Models.UserContentComment>();

            CreateMap<CommentViewModel, Domain.Models.BrainstormComment>();

            #endregion General

            #region Game

            CreateMap<GameViewModel, Domain.Models.Game>()
                    .ForMember(dest => dest.DeveloperName, opt => opt.MapFrom(src => src.AuthorName))
                    .ForMember(dest => dest.Platforms, opt => opt.MapFrom<GamePlatformToDomainResolver>())
                    .ForMember(dest => dest.ExternalLinks, opt => opt.Ignore())
                    .AfterMap<AddOrUpdateGameExternalLinks>();

            #endregion Game

            #region Profile

            CreateMap<ProfileViewModel, Domain.Models.UserProfile>()
                .ForMember(dest => dest.Followers, opt => opt.Ignore())
                .AfterMap<AddOrUpdateProfileExternalLinks>();

            #endregion Profile

            #region Content

            CreateMap<UserContentViewModel, Domain.Models.UserContent>();

            #endregion Content

            #region Brainstorm

            CreateMap<BrainstormSessionViewModel, Domain.Models.BrainstormSession>();
            CreateMap<BrainstormIdeaViewModel, Domain.Models.BrainstormIdea>();
            CreateMap<BrainstormVoteViewModel, Domain.Models.BrainstormVote>();
            CreateMap<BrainstormCommentViewModel, Domain.Models.BrainstormComment>();

            #endregion Brainstorm

            #region Gamification

            CreateMap<UserBadgeViewModel, Domain.Models.UserBadge>();

            #endregion Gamification

            #region Interactions

            CreateMap<GameFollowViewModel, Domain.Models.GameFollow>();

            CreateMap<UserFollowViewModel, Domain.Models.UserFollow>();

            CreateMap<UserConnectionViewModel, Domain.Models.UserConnection>();

            #endregion Interactions

            #region Team

            CreateMap<TeamViewModel, Domain.Models.Team>()
                .ForMember(dest => dest.Members, opt => opt.Ignore())
                .AfterMap<AddOrUpdateTeamMembers>();
            CreateMap<TeamMemberViewModel, Domain.Models.TeamMember>()
                    .ForMember(dest => dest.Work, opt => opt.MapFrom<TeamWorkToDomainResolver>());

            #endregion Team


            #region Jobs

            CreateMap<JobPositionViewModel, JobPosition>()
                .ForMember(dest => dest.Applicants, opt => opt.Ignore());
            CreateMap<JobApplicantViewModel, JobApplicant>();

            #endregion Jobs
        }
    }
}