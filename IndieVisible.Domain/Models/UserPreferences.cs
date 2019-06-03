using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class UserPreferences : Entity
    {
        public SupportedLanguage UiLanguage { get; set; }

        public string ContentLanguages { get; set; }
    }
}
