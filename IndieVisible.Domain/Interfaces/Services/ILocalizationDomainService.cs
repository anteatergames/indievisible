using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using IndieVisible.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Interfaces.Service
{
    public interface ILocalizationDomainService : IDomainService<Localization>
    {
        Localization GenerateNewProject(Guid userId);

        IEnumerable<Guid> GetTranslatedGamesByUserId(Guid userId);

        Localization GetBasicInfoById(Guid id);

        double CalculatePercentage(int totalTerms, int translatedCount, int languageCount);

        IEnumerable<LocalizationEntry> GetEntries(Guid projectId, SupportedLanguage language);

        bool AddEntry(Guid projectId, LocalizationEntry entry);

        IEnumerable<LocalizationTerm> GetTerms(Guid projectId);

        LocalizationStatsVo GetPercentageByGameId(Guid gameId);

        void SetTerms(Guid projectId, IEnumerable<LocalizationTerm> terms);

        void SaveEntries(Guid projectId, IEnumerable<LocalizationEntry> entries);

        Task<List<InMemoryFileVo>> GetXmlById(Guid projectId, bool fillGaps);

        Task<InMemoryFileVo> GetXmlById(Guid projectId, SupportedLanguage language, bool fillGaps);

        Task<List<Guid>> GetContributors(Guid projectId, ExportContributorsType type);

        void AcceptEntry(Guid projectId, Guid entryId);

        void RejectEntry(Guid projectId, Guid entryId);
    }
}