using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Domain.Interfaces.Repository
{
    public interface ILocalizationRepository : IRepository<Localization>
    {
        Localization GetBasicInfoById(Guid id);

        int CountTerms(Func<LocalizationTerm, bool> where);

        IQueryable<LocalizationTerm> GetTerms(Guid translationProjectId);

        Task<bool> AddTerm(Guid translationProjectId, LocalizationTerm term);

        Task<bool> RemoveTerm(Guid translationProjectId, Guid termId);

        Task<bool> UpdateTerm(Guid translationProjectId, LocalizationTerm term);

        int CountEntries(Func<LocalizationEntry, bool> where);

        IQueryable<LocalizationEntry> GetEntries(Guid translationProjectId);

        Task<bool> AddEntry(Guid translationProjectId, LocalizationEntry entry);

        IEnumerable<Guid> GetTranslatedGamesByUserId(Guid userId);

        Task<bool> RemoveEntry(Guid translationProjectId, Guid entryId);

        void UpdateEntry(Guid translationProjectId, LocalizationEntry entry);

        IQueryable<LocalizationEntry> GetEntries(Guid projectId, SupportedLanguage language);

        IQueryable<LocalizationEntry> GetEntries(Guid projectId, SupportedLanguage language, Guid termId);

        LocalizationEntry GetEntry(Guid projectId, Guid entryId);
    }
}