using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class GamificationAction : Entity
    {
        public PlatformAction Action { get; set; }

        public int ScoreValue { get; set; }
    }
}
