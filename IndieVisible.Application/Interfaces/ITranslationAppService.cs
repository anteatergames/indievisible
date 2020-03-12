using IndieVisible.Application.ViewModels.Translation;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IndieVisible.Application.Interfaces
{
    public interface ITranslationAppService : ICrudAppService<TranslationProjectViewModel>, IPermissionControl<TranslationProjectViewModel>
    {
        OperationResultVo GenerateNew(Guid currentUserId);

        OperationResultVo GetByUserId(Guid currentUserId, Guid userId);

        OperationResultVo GetMyUntranslatedGames(Guid currentUserId);

        OperationResultVo GetTranslations(Guid currentUserId, Guid projectId, SupportedLanguage language);

        OperationResultVo SetTranslationEntry(Guid currentUserId, Guid projectId, TranslationEntryViewModel vm);
        
        Task<OperationResultVo> ReadTermsSheet(Guid currentUserId, Guid projectId, IEnumerable<KeyValuePair<int, SupportedLanguage>> columns, IFormFile termsFile);
    }
}