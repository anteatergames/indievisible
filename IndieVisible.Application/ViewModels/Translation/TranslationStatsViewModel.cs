using IndieVisible.Domain.Core.Enums;
using System.Collections.Generic;

namespace IndieVisible.Application.ViewModels.Translation
{
    public class TranslationStatsViewModel : TranslationProjectViewModel
    {
        public List<ContributorViewModel> Contributors { get; set; }
        public List<TranslationStatsLanguageViewModel> Languages { get; set; }

        public TranslationStatsViewModel() : base()
        {
            Contributors = new List<ContributorViewModel>();
            Languages = new List<TranslationStatsLanguageViewModel>();
        }
    }
    public class TranslationStatsLanguageViewModel
    {
        public SupportedLanguage Language { get; set; }

        public int EntryCount { get; set; }

        public double Percentage { get; set; }

        public TranslationStatsLanguageViewModel() : base()
        {
        }
    }
}