using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IndieVisible.Application.ViewModels.User
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileType Type { get; set; }

        public string UserName { get; set; }

        [Required]
        [Display(Name = "Display Name")]
        public string Name { get; set; }

        [Display(Name = "Motto")]
        public string Motto { get; set; }

        public string ProfileImageUrl { get; set; }

        public string CoverImageUrl { get; set; }

        [Display(Name = "Bio")]
        public string Bio { get; set; }

        [Display(Name = "Studio Name")]
        public string StudioName { get; set; }

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
        #endregion


        public UserCounters Counters { get; set; }

        public IndieXpCounter IndieXp { get; set; }

        public List<UserProfileExternalLinkViewModel> ExternalLinks { get; set; }

        public ConnectionControlViewModel ConnectionControl { get; set; }

        public ProfileViewModel()
        {
            Counters = new UserCounters();
            IndieXp = new IndieXpCounter();
            ExternalLinks = new List<UserProfileExternalLinkViewModel>();
            ConnectionControl = new ConnectionControlViewModel();
        }
    }

    public class IndieXpCounter
    {
        public int Level { get; set; }

        public int LevelXp { get; set; }

        public int NextLevelXp { get; set; }

        public int XpToNextLevel
        {
            get
            {
                return NextLevelXp - LevelXp;
            }
        }

        public int PercentageToNextLevel
        {
            get
            {
                int percentage = (int)Math.Round((double)(100 * LevelXp) / NextLevelXp);

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

        public bool CurrentUserWantsToFollowMe { get; set; }
    }
}
