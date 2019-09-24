using IndieVisible.Domain.Core.Models;
using System;

namespace IndieVisible.Domain.Models
{
    public class BrainstormComment : Entity
    {
        public Guid? ParentCommentId { get; set; }

        public Guid IdeaId { get; set; }

        public string AuthorName { get; set; }

        public string AuthorPicture { get; set; }

        public string Text { get; set; }

        public virtual BrainstormIdea Idea { get; set; }
    }
}
