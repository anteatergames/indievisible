using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.ViewModels.Search
{
    public class UserContentSearchViewModel
    {
        public Guid ContentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string FeaturedImage { get; set; }
        public SupportedLanguage Language { get; set; }
    }
}
