using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Domain.Core.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels.Localization
{
    public class LocalizationViewModel : UserGeneratedBaseViewModel
    {
        [Required(ErrorMessage = "You need to tell people a little about your translation!")]
        [Display(Name = "Introduction")]
        public string Introduction { get; set; }

        [Display(Name = "Primary Language")]
        public SupportedLanguage PrimaryLanguage { get; set; }

        [Display(Name = "Term Count")]
        public int TermCount { get; set; }

        [Display(Name = "Game")]
        public GameBaseViewModel Game { get; set; }

        [Display(Name = "Terms")]
        public List<LocalizationTermViewModel> Terms { get; set; }

        [Display(Name = "Entries")]
        public List<LocalizationEntryViewModel> Entries { get; set; }

        public LocalizationViewModel()
        {
            Game = new GameBaseViewModel();
        }

        public double TranslationPercentage { get; set; }


        public string TranslationPercentageText
        {
            get
            {
                string text = TranslationPercentage.ToString("N1");

                if (TranslationPercentage == 0 || TranslationPercentage == 100 || text.Substring(text.Length - 1).Equals("0"))
                {
                    return TranslationPercentage.ToString("N0");
                }
                else
                {
                    return text;
                }
            }
        }
    }
}