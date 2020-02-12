using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

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
