using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;

namespace IndieVisible.Domain.Models
{
    public class UserBadge : Entity
    {
        public BadgeType Badge { get; set; }
    }
}
