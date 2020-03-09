using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum GameStatus
    {
        [Display(Name = "Planned")]
        Planned,

        [Display(Name = "Concept")]
        Concept,

        [Display(Name = "In Progress")]
        InProgress,

        [Display(Name = "Alpha")]
        Alpha,

        [Display(Name = "Beta")]
        Beta,

        [Display(Name = "Released")]
        Released,

        [Display(Name = "Cancelled")]
        Cancelled
    }
}