using IndieVisible.Domain.Core.Models;

namespace IndieVisible.Domain.Models
{
    public class Gamification : Entity
    {
        public int CurrentLevelNumber { get; set; }

        public int XpTotal { get; set; }

        public int XpCurrentLevel { get; set; }

        public int XpToNextLevel { get; set; }
    }
}
