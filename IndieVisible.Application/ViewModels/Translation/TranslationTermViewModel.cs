using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IndieVisible.Application.ViewModels.Translation
{
    public class TranslationTermViewModel : UserGeneratedBaseViewModel
    {
        [Required(ErrorMessage = "You must provide a key for the term!")]
        [Display(Name = "Key")]
        public string Key { get; set; }

        [Required(ErrorMessage = "You must provide a value for the primary language!")]
        [Display(Name = "Value")]
        public string Value { get; set; }

        [Display(Name = "Context")]
        public string Obs { get; set; }
    }
}
