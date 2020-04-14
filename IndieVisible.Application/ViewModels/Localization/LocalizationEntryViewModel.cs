using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Application.ViewModels.Localization
{
    public class LocalizationEntryViewModel : UserGeneratedBaseViewModel
    {
        public Guid TermId { get; set; }

        public SupportedLanguage Language { get; set; }

        public string Value { get; set; }

        public bool? Accepted { get; set; }
    }
}