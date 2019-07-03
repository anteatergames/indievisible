using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IndieVisible.Application.ViewModels.UserPreferences
{
    public class UserPreferencesViewModel : BaseViewModel
    {
        [Display(Name = "UI Language")]
        public SupportedLanguage UiLanguage { get; set; }

        [Display(Name = "Content Language")]
        public string ContentLanguages { get; set; }

        [Display(Name = "Content Language")]
        public List<SupportedLanguage> Languages { get; set; }

        public string StatusMessage { get; set; }
    }
}
