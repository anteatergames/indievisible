using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Application.ViewModels.Translation
{
    public class TranslationEntryViewModel : UserGeneratedBaseViewModel
    {
        public Guid TermId { get; set; }

        public SupportedLanguage Language { get; set; }

        public string Value { get; set; }
    }
}