using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class StudyActivity : Entity
    {
        public Guid ActivityId { get; set; }

        public int Order { get; set; }
    }
}
