using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.ValueObjects
{
    public class RankingVo
    {
        public Gamification Gamification { get; set; }

        public GamificationLevel Level { get; set; }
    }
}
