using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
