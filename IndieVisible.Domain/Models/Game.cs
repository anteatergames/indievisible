using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Models
{
    public class Game : ExternalEntity
    {
        public Game()
        {

        }
        public string DeveloperName { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public GameGenre Genre { get; set; }

        public string CoverImageUrl { get; set; }

        public string ThumbnailUrl { get; set; }

        public GameEngine Engine { get; set; }

        public string CustomEngineName { get; set; }

        public CodeLanguage Language { get; set; }

        public string WebsiteUrl { get; set; }

        public GameStatus Status { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Platforms { get; set; }

        public virtual ICollection<UserContent> UserContents { get; set; }


        #region Social
        public string FacebookUrl { get; set; }

        public string TwitterUrl { get; set; }

        public string InstagramUrl { get; set; }
        #endregion
    }
}
