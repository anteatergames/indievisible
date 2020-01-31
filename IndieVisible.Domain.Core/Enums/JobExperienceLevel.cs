using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum JobExperienceLevel
    {
        [Display(Name = "All Levels")]
        AllLevels = 0,
        [Display(Name = "Associate")]
        Associate = 1,
        [Display(Name = "Junior")]
        Junior = 2,
        [Display(Name = "Mid-Senior")]
        MidSenior = 3,
        [Display(Name = "Senior")]
        Senior = 4,
        [Display(Name = "Director")]
        Director = 4
    }
}
