using IndieVisible.Domain.Core.Models;
using System;

namespace IndieVisible.Domain.Models
{
    public class StudyActivity : Entity
    {
        public Guid ActivityId { get; set; }

        public int Order { get; set; }
    }
}
