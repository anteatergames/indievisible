using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;

namespace IndieVisible.Domain.Models
{
    public class GamificationAction : Entity
    {
        public PlatformAction Action { get; set; }

        public int ScoreValue { get; set; }
    }
}