using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;

namespace IndieVisible.Domain.Models
{
    public class Notification : Entity
    {
        public NotificationType Type { get; set; }

        public bool IsRead { get; set; }

        public string Text { get; set; }

        public string Url { get; set; }
    }
}
