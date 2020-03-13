using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface ITranslationDomainService : IDomainService<TranslationProject>
    {
        TranslationProject GenerateNewProject(Guid userId);

        IEnumerable<Guid> GetTranslatedGamesByUserId(Guid userId);

        TranslationProject GetBasicInfoById(Guid id);

        IEnumerable<TranslationEntry> GetEntries(Guid projectId, SupportedLanguage language);

        void SetEntry(Guid projectId, TranslationEntry entry);

        IEnumerable<TranslationTerm> GetTerms(Guid projectId);

        void SetTerms(Guid projectId, IEnumerable<TranslationTerm> terms);

        void SaveEntries(Guid projectId, IEnumerable<TranslationEntry> entries);
    }
}