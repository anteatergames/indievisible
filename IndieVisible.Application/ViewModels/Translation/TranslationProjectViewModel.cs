using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IndieVisible.Application.ViewModels.Translation
{
    public class TranslationProjectViewModel : UserGeneratedBaseViewModel
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
        public List<TranslationTermViewModel> Terms { get; set; }

        [Display(Name = "Entries")]
        public List<TranslationEntryViewModel> Entries { get; set; }

        public TranslationProjectViewModel()
        {
            Game = new GameBaseViewModel();
        }

        public double TranslationPercentage { get; set; }
    }
}
