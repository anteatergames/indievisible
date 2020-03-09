using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum JobProfile
    {
        [Display(Name = "Company")]
        Company = 1,
        [Display(Name = "Applicant")]
        Applicant = 2
    }
}
