using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum JobPositonType
    {
        [Display(Name = "Not Defined")]
        NotDefined = 0,
        [Display(Name = "Contract")]
        Contract = 1,
        [Display(Name = "Permanent")]
        Permanent = 2,
        [Display(Name = "Temporary")]
        Temporary = 3,
        [Display(Name = "Full Time")]
        FullTime = 4,
        [Display(Name = "Part Time")]
        PartTime = 5,
        [Display(Name = "Freelance")]
        Freelance = 6
    }
}
