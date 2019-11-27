using IndieVisible.Domain.Core.Models;

namespace IndieVisible.Domain.Models
{
    public class GamificationLevel : Entity
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public int XpToAchieve { get; set; }
    }
}