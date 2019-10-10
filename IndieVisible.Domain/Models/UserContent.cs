using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Models
{
    public class UserContent : Entity
    {
        public string AuthorName { get; set; }

        public string AuthorPicture { get; set; }

        public string FeaturedImage { get; set; }

        public string Title { get; set; }

        public string Introduction { get; set; }

        public string Content { get; set; }

        public UserContentType UserContentType { get; set; }

        public SupportedLanguage Language { get; set; }

        public Guid? GameId { get; set; }
        public virtual Game Game { get; set; }

        public virtual ICollection<UserContentLike> Likes { get; set; }

        public virtual ICollection<UserContentComment> Comments { get; set; }

        public virtual ICollection<Poll> Polls { get; set; }
    }
}
