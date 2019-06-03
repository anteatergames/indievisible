using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Models
{
    public class BrainstormSession : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public BrainstormSessionType Type { get; set; }

        public Guid? TargetContextId { get; set; }

        public virtual ICollection<BrainstormIdea> Ideas { get; set; }
    }
}
