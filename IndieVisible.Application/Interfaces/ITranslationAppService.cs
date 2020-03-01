using IndieVisible.Application.ViewModels.Jobs;
using IndieVisible.Application.ViewModels.Translation;
using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.ValueObjects;
using System;

namespace IndieVisible.Application.Interfaces
{
    public interface ITranslationAppService : ICrudAppService<TranslationProjectViewModel>, IPermissionControl<TranslationProjectViewModel>
    {
    }
}