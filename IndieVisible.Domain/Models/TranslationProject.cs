using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class TranslationProject : Entity
    {
        public Guid GameId { get; set; }
        
        public SupportedLanguage PrimaryLanguage { get; set; }

        public string Introduction { get; set; }

        public List<TranslationTerm> Terms { get; set; }

        public List<TranslationEntry> Entries { get; set; }

        public TranslationProject()
        {
            Terms = new List<TranslationTerm>();
            Entries = new List<TranslationEntry>();
        }
    }
}
