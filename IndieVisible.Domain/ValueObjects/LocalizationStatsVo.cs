using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.ValueObjects
{
    public class LocalizationStatsVo
    {
        public Guid LocalizationId { get; set; }

        public int TermCount { get; set; }

        public List<LocalizationEntry> Entries { get; set; }

        public double LocalizationPercentage { get; internal set; }
    }
}
