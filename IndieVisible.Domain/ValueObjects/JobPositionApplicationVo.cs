using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Domain.ValueObjects
{
    public class JobPositionApplicationVo
    {
        public Guid JobPositionId { get; set; }

        public DateTime ApplicationDate { get; set; }

        public WorkType WorkType { get; set; }

        public String Location { get; set; }
    }
}
