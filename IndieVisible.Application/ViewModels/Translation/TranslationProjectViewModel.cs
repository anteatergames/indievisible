using IndieVisible.Application.ViewModels.Game;
using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.ViewModels.Translation
{
    public class TranslationProjectViewModel : UserGeneratedBaseViewModel
    {
        public string Introduction { get; set; }

        public SupportedLanguage PrimaryLanguage { get; set; }

        public int TermCount { get; set; }

        public GameBaseViewModel Game { get; set; }

        public List<TranslationTermViewModel> Terms { get; set; }

        public List<TranslationEntryViewModel> Entries { get; set; }

        public TranslationProjectViewModel()
        {
            Game = new GameBaseViewModel();
        }
    }
}
