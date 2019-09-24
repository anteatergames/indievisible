using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;

namespace IndieVisible.Domain.Models
{
    public class BrainstormVote : Entity
    {
        public Guid IdeaId { get; set; }

        public VoteValue VoteValue { get; set; }

        public virtual BrainstormIdea Idea { get; set; }
    }
}
