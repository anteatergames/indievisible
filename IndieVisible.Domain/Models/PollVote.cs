using IndieVisible.Domain.Core.Models;
using System;

namespace IndieVisible.Domain.Models
{
    public class PollVote : Entity
    {
        public Guid PollId { get; set; }

        public Guid PollOptionId { get; set; }
    }
}