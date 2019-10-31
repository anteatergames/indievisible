using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Models
{
    public class Poll : Entity
    {
        public Guid? UserContentId { get; set; }

        public bool MultipleChoice { get; set; }

        public bool UsersCanAddOptions { get; set; }

        public DateTime? CloseDate { get; set; }

        public string Title { get; set; }

        public virtual UserContent UserContent { get; set; }

        public virtual ICollection<PollOption> Options { get; set; }

        public Poll()
        {
            Options = new List<PollOption>();
        }
    }
}
