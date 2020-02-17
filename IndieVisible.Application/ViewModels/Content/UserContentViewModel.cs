using IndieVisible.Application.Interfaces;
using IndieVisible.Application.ViewModels.Poll;
using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace IndieVisible.Application.ViewModels.Content
{
    public class UserContentViewModel : UserGeneratedCommentBaseViewModel, ICommentableItem
    {
        [Display(Name = "Featured Image")]
        public string FeaturedImage { get; set; }
        public string FeaturedImageResponsive { get; set; }
        public string FeaturedImageLquip { get; set; }

        [Display(Name = "Images")]
        public List<string> Images { get; set; }

        [StringLength(128)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Introduction")]
        public string Introduction { get; set; }

        [Display(Name = "Content")]
        //[Required(ErrorMessage = "The Content is required")]
        public string Content { get; set; }

        [Display(Name = "Related Game")]
        public Guid? GameId { get; set; }

        public string GameTitle { get; set; }

        public string GameThumbnail { get; set; }

        public bool HasFeaturedImage { get; set; }

        public MediaType FeaturedMediaType { get; set; }

        public bool IsComplex { get { return HasFeaturedImage; } }

        public bool HasPoll { get { return Poll != null && Poll.PollOptions.Any(); } }

        public PollViewModel Poll { get; set; }

        public bool IsArticle { get; set; }
    }
}