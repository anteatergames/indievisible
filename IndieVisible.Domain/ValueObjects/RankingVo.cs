using IndieVisible.Domain.Models;

namespace IndieVisible.Domain.ValueObjects
{
    public class RankingVo
    {
        public Gamification Gamification { get; set; }

        public GamificationLevel Level { get; set; }
    }
}