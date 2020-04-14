using IndieVisible.Application.ViewModels.Localization;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndieVisible.Application.Interfaces
{
    public interface ILocalizationAppService : ICrudAppService<LocalizationViewModel>, IPermissionControl<LocalizationViewModel>
    {
        OperationResultVo GenerateNew(Guid currentUserId);

        OperationResultVo GetByUserId(Guid currentUserId, Guid userId);

        OperationResultVo GetBasicInfoById(Guid currentUserId, Guid id);        

        OperationResultVo GetMyUntranslatedGames(Guid currentUserId);

        OperationResultVo GetTranslations(Guid currentUserId, Guid projectId, SupportedLanguage language);

        OperationResultVo GetTerms(Guid currentUserId, Guid projectId);

        OperationResultVo SaveEntry(Guid currentUserId, Guid projectId, LocalizationEntryViewModel vm);
        
        Task<OperationResultVo> ReadTermsSheet(Guid currentUserId, Guid projectId, IEnumerable<KeyValuePair<int, SupportedLanguage>> columns, IFormFile termsFile);

        OperationResultVo SetTerms(Guid currentUserId, Guid projectId, IEnumerable<LocalizationTermViewModel> terms);

        OperationResultVo SaveEntries(Guid currentUserId, Guid projectId, SupportedLanguage language, IEnumerable<LocalizationEntryViewModel> entries);

        OperationResultVo GetStatsById(Guid currentUserId, Guid id);

        OperationResultVo GetPercentageByGameId(Guid currentUserId, Guid gameId);

        OperationResultVo GetXml(Guid currentUserId, Guid projectId, SupportedLanguage? language, bool fillGaps);

        OperationResultVo GetContributorsFile(Guid currentUserId, Guid projectId, ExportContributorsType type);

        OperationResultVo EntryReview(Guid currentUserId, Guid projectId, Guid entryId, bool accept);
    }
}