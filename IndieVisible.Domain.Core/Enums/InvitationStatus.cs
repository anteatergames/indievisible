using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum InvitationStatus
    {
        [Display(Name = "Invited")]
        Invited = 1,

        [Display(Name = "Accepted")]
        Accepted = 2,

        [Display(Name = "Rejected")]
        Rejected = 3,

        [Display(Name = "Candidate")]
        Candidate = 4
    }
}