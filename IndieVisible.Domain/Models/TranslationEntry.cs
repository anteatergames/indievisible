using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;

namespace IndieVisible.Domain.Models
{
    public class TranslationEntry : Entity
    {
        public Guid TermId { get; set; }

        public SupportedLanguage Language { get; set; }

        public string Value { get; set; }

        public bool? Accepted { get; set; }
    }
}