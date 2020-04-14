using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Models
{
    public class Localization : Entity
    {
        public Guid GameId { get; set; }

        public SupportedLanguage PrimaryLanguage { get; set; }

        public string Introduction { get; set; }

        public List<LocalizationTerm> Terms { get; set; }

        public List<LocalizationEntry> Entries { get; set; }

        public Localization()
        {
            Terms = new List<LocalizationTerm>();
            Entries = new List<LocalizationEntry>();
        }
    }
}