using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Domain.ValueObjects
{
    public class UserContentSearchVo
    {
        public Guid ContentId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string FeaturedImage { get; set; }
        public SupportedLanguage Language { get; set; }
    }
}