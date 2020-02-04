using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum JobPositionDuration
    {
        [Display(Name = "Not Informed")]
        NotInformed = 0,
        [Display(Name = "Permanent")]
        Permanent = 1,
        [Display(Name = "Temporary")]
        Temporary = 2
    }
}
