using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.ViewModels.Translation
{
    public class TranslationTermViewModel : UserGeneratedBaseViewModel
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public bool Fuzzy { get; set; }
    }
}
