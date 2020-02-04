using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum JobPositonType
    {
        [Display(Name = "Not Informed")]
        NotInformed = 0,
        [Display(Name = "Contract")]
        Contract = 1,
        [Display(Name = "Full Time")]
        FullTime = 2,
        [Display(Name = "Part Time")]
        PartTime = 3,
        [Display(Name = "Freelance")]
        Freelance = 4
    }
}
