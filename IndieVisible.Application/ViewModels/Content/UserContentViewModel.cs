using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels.Content
{
    public class UserContentViewModel : UserGeneratedBaseViewModel
    {

        [Display(Name = "Featured Image")]
        public string FeaturedImage { get; set; }
        [Display(Name = "Images")]
        public List<string> Images { get; set; }

        [StringLength(128)]
        [Display(Name = "Title")]
        [Required(ErrorMessage = "The Title is required")]
        public string Title { get; set; }

        [Display(Name = "Introduction")]
        [Required(ErrorMessage = "The Introduction is required")]
        public string Introduction { get; set; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "The Content is required")]
        public string Content { get; set; }

        [Display(Name = "Language")]
        public SupportedLanguage Language { get; set; }

        [Display(Name = "Related Game")]
        public Guid? GameId { get; set; }
        public string GameTitle { get; set; }
        public string GameThumbnail { get; set; }

        public bool HasFeaturedImage { get; set; }
        public MediaType FeaturedMediaType { get; set; }

        public bool IsComplex { get { return !string.IsNullOrWhiteSpace(this.Title) && !string.IsNullOrWhiteSpace(this.FeaturedImage); } }
    }
}
