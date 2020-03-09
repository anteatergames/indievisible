using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum JobExperienceLevel
    {
        [Display(Name = "Not Informed")]
        NotInformed = 0,

        [Display(Name = "All Levels")]
        AllLevels = 1,

        [Display(Name = "Associate")]
        Associate = 2,

        [Display(Name = "Junior")]
        Junior = 3,

        [Display(Name = "Mid-Senior")]
        MidSenior = 4,

        [Display(Name = "Senior")]
        Senior = 5,

        [Display(Name = "Director")]
        Director = 6
    }
}