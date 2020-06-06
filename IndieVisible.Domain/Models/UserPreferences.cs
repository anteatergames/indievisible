using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;

namespace IndieVisible.Domain.Models
{
    public class UserPreferences : Entity
    {
        public SupportedLanguage UiLanguage { get; set; }

        public string ContentLanguages { get; set; }

        public JobProfile JobProfile { get; set; }

        public StudyProfile StudyProfile { get; set; }
    }
}