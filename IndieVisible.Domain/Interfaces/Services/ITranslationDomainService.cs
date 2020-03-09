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

        IEnumerable<TranslationEntry> GetTranslations(Guid projectId, SupportedLanguage language);
    }
}