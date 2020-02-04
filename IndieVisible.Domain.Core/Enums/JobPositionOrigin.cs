using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum JobPositionOrigin
    {
        [Display(Name = "Internal")]
        Internal = 1,
        [Display(Name = "External")]
        External = 2
    }
}
