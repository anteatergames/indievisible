using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum PaymentFrequency
    {
        [Display(Name = "Not Informed")]
        NotInformed,

        [Display(Name = "Hour")]
        Hour,

        [Display(Name = "Day")]
        Day,

        [Display(Name = "Week")]
        Week,

        [Display(Name = "Month")]
        Month,

        [Display(Name = "Year")]
        Year
    }
}