using IndieVisible.Domain.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels.Localization
{
    public class LocalizationTermViewModel : UserGeneratedBaseViewModel
    {
        [Required(ErrorMessage = "You must provide a key for the term!")]
        [Display(Name = "Key")]
        public string Key { get; set; }

        [Required(ErrorMessage = "You must provide a value for the primary language!")]
        [Display(Name = "Value")]
        public string Value { get; set; }

        [Display(Name = "Context")]
        public string Obs { get; set; }

        public SupportedLanguage PrimaryLanguage { get; set; }
    }
}