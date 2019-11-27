using IndieVisible.Domain.Core.Models;
using System;

namespace IndieVisible.Domain.Models
{
    public class UserContentComment : Entity
    {
        public Guid ParentCommentId { get; set; }

        public Guid UserContentId { get; set; }

        public string AuthorName { get; set; }

        public string AuthorPicture { get; set; }

        public string Text { get; set; }
    }
}