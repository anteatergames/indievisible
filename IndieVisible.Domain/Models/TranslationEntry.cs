using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class TranslationEntry : Entity
    {
        public Guid TermId { get; set; }

        public SupportedLanguage Language { get; set; }

        public string Value { get; set; }
    }
}
