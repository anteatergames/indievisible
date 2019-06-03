using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class BrainstormVote : Entity
    {
        public Guid IdeaId { get; set; }

        public VoteValue VoteValue { get; set; }

        public virtual BrainstormIdea Idea { get; set; }
    }
}
