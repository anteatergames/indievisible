using System;

namespace IndieVisible.Application.ViewModels.Gamification
{
    public class RankingViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string ProfileImageUrl { get; set; }

        public string CoverImageUrl { get; set; }

        public string Location { get; set; }

        public string CurrentLevelName { get; set; }

        public int CurrentLevelNumber { get; set; }

        public int XpTotal { get; set; }

        public int XpCurrentLevel { get; set; }

        public int XpToNextLevel { get; set; }

        public int PercentageToNextLevel
        {
            get
            {
                int percentage = (int)Math.Round((double)(100 * XpCurrentLevel) / XpToNextLevel);

                return percentage;
            }
        }
    }
}