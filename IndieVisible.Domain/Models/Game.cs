using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Models
{
    public class Game : Entity
    {
        public string DeveloperName { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public GameGenre Genre { get; set; }

        public Guid? TeamId { get; set; }

        public string CoverImageUrl { get; set; }

        public string ThumbnailUrl { get; set; }

        public GameEngine Engine { get; set; }

        public string CustomEngineName { get; set; }

        public CodeLanguage Language { get; set; }

        public GameStatus Status { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Platforms { get; set; }

        public virtual Team Team { get; set; }

        public virtual List<UserContent> UserContents { get; set; }

        public virtual List<GameExternalLink> ExternalLinks { get; set; }

        public virtual List<GameFollow> Followers { get; set; }

        public virtual List<GameLike> Likes { get; set; }
    }
}