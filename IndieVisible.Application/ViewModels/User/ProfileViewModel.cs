using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IndieVisible.Application.ViewModels.User
{
    public class ProfileViewModel : BaseViewModel, IUserProfileBasic
    {
        public ProfileType Type { get; set; }

        public string UserName { get; set; }

        [Required]
        [Display(Name = "Display Name")]
        public string Name { get; set; }

        [Display(Name = "Motto")]
        public string Motto { get; set; }

        public string ProfileImageUrl { get; set; }

        public bool HasCoverImage { get; set; }

        public string CoverImageUrl { get; set; }

        [Display(Name = "Bio")]
        public string Bio { get; set; }

        [Display(Name = "Studio Name")]
        public string StudioName { get; set; }

        [Display(Name = "country")]
        public string Country { get; set; }

        [Display(Name = "location")]
        public string Location { get; set; }

        #region ExternalHandles

        public bool HasOtherProfiles
        {
            get
            {
                return ExternalLinks.Any(x => x.Type == ExternalLinkType.GameDev);
            }
        }

        #endregion ExternalHandles

        public UserCounters Counters { get; set; }

        public IndieXpCounter IndieXp { get; set; }

        public List<ExternalLinkBaseViewModel> ExternalLinks { get; set; }
        public List<UserFollowViewModel> Followers { get; set; }
        public List<UserConnectionViewModel> Connections { get; set; }

        public ConnectionControlViewModel ConnectionControl { get; set; }

        public ProfileViewModel()
        {
            Counters = new UserCounters();
            IndieXp = new IndieXpCounter();
            ExternalLinks = new List<ExternalLinkBaseViewModel>();
            ConnectionControl = new ConnectionControlViewModel();
        }
    }

    public class IndieXpCounter
    {
        public int CurrentLevelNumber { get; set; }

        public int XpCurrentLevel { get; set; }

        public int XpCurrentLevelMax { get; set; }

        public int XpToNextLevel
        {
            get
            {
                return XpCurrentLevelMax - XpCurrentLevel;
            }
        }

        public int PercentageToNextLevel
        {
            get
            {
                int percentage = (int)Math.Round((double)(100 * XpCurrentLevel) / XpCurrentLevelMax);

                return percentage;
            }
        }

        public string LevelName { get; set; }
    }

    public class UserCounters
    {
        public int Followers { get; set; }

        public int Following { get; set; }

        public int Connections { get; set; }

        public int Games { get; set; }

        public int Posts { get; set; }

        public int Comments { get; set; }

        public int Jams { get; set; }
    }

    public class ConnectionControlViewModel
    {
        public bool ConnectionIsPending { get; set; }

        public bool CurrentUserConnected { get; set; }

        public bool CurrentUserWantsToConnect { get; set; }

        public UserConnectionType? ConnectionType { get; set; }
    }
}