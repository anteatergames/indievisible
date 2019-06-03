using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class GamificationLevel : Entity
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public int XpToAchieve { get; set; }
    }
}
