using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface ITranslationDomainService : IDomainService<TranslationProject>
    {
        TranslationProject GenerateNewProject(Guid userId);

        IEnumerable<Guid> GetTranslatedGamesByUserId(Guid userId);

        TranslationProject GetBasicInfoById(Guid id);

        IEnumerable<TranslationEntry> GetEntries(Guid projectId, SupportedLanguage language);

        void SaveEntry(Guid projectId, TranslationEntry entry);

        IEnumerable<TranslationTerm> GetTerms(Guid projectId);

        void SetTerms(Guid projectId, IEnumerable<TranslationTerm> terms);

        void SaveEntries(Guid projectId, IEnumerable<TranslationEntry> entries);

        Task<List<InMemoryFileVo>> GetXmlById(Guid projectId, bool fillGaps);

        Task<InMemoryFileVo> GetXmlById(Guid projectId, SupportedLanguage language, bool fillGaps);

        Task<List<Guid>> GetContributors(Guid projectId, ExportContributorsType type);
    }
}