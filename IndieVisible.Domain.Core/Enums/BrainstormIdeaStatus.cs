using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum BrainstormIdeaStatus
    {
        [Display(Name = "Proposed")]
        Proposed = 1,

        [Display(Name = "In Analysis")]
        InAnalysis = 2,

        [Display(Name = "Accepted")]
        Accepted = 3,

        [Display(Name = "Rejected")]
        Rejected = 4,

        [Display(Name = "Implemented")]
        Implemented = 5
    }
}