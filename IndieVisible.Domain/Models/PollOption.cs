using IndieVisible.Domain.Core.Models;
using System;

namespace IndieVisible.Domain.Models
{
    public class PollOption : Entity
    {
        public Guid PollId { get; set; }

        public int Index { get; set; }

        public string Text { get; set; }

        public string Image { get; set; }

        public virtual Poll Poll { get; set; }
    }
}