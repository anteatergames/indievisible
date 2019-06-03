using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Models
{
    public class ProfileViewModel
    {
        public string Name { get; internal set; }
        public string Motto { get; internal set; }
        public string CoverImageUrl { get; internal set; }
        public string Bio { get; internal set; }
        public string StudioName { get; internal set; }
        public string Location { get; internal set; }

        public UserCounters Counters { get; set; }

        public IndieXpCounter IndieXp { get; set; }

        public Dictionary<ExternalLinks, string> ExternalLinks { get; set; }

        public ProfileViewModel()
        {
            Counters = new UserCounters();
            IndieXp = new IndieXpCounter();
            ExternalLinks = new Dictionary<ExternalLinks, string>();
        }
    }

    public class IndieXpCounter
    {
        public int Level { get; set; }

        public int LevelXp { get; set; }

        public int NextLevelXp { get; set; }

        public int XpToNextLevel { get
            {
                return NextLevelXp - LevelXp;
            }
        }

        public int PercentageToNextLevel
        {
            get
            {
                var percentage = (int)Math.Round((double)(100 * LevelXp) / NextLevelXp);

                return percentage;
            }
        }
    }

    public class UserCounters
    {
        public int Followers { get; set; }
        public int Following { get; set; }
        public int Likes { get; set; }
        public int Games { get; set; }
        public int Posts { get; set; }
        public int Comments { get; set; }
        public int Jams { get; set; }
    }
}
