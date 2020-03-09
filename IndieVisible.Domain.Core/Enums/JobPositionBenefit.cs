using IndieVisible.Domain.Core.Attributes;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Domain.Core.Enums
{
    public enum JobPositionBenefit
    {
        [Display(Name = "Not Informed")]
        [UiInfo(Display = "Not Informed", Class = "times")]
        NotInformed = 0,

        [Display(Name = "Flexible Hours")]
        [UiInfo(Display = "Flexible Hours", Class = "clock")]
        FlexibleHours,

        [Display(Name = "Free Coffee")]
        [UiInfo(Display = "Free Coffee", Class = "coffee")]
        FreeCoffee,

        [Display(Name = "Transportation")]
        [UiInfo(Display = "Transportation", Class = "car")]
        Transportation,

        [Display(Name = "Meals")]
        [UiInfo(Display = "Meals", Class = "utensils")]
        Meals,

        [Display(Name = "Health Insurance")]
        [UiInfo(Display = "Health Insurance", Class = "first-aid")]
        HealthInsurance,

        [Display(Name = "Dental Insurance")]
        [UiInfo(Display = "Dental Insurance", Class = "tooth")]
        DentalInsurance,

        [Display(Name = "Life Insurance")]
        [UiInfo(Display = "Life Insurance", Class = "heartbeat")]
        LifeInsurance,

        [Display(Name = "Gym Membership")]
        [UiInfo(Display = "Gym Membership", Class = "dumbbell")]
        GymMembership,

        [Display(Name = "Retirement Plan")]
        [UiInfo(Display = "Retirement Plan", Class = "couch")]
        RetirementPlan,

        [Display(Name = "Paid Vacation")]
        [UiInfo(Display = "Paid Vacation", Class = "plane")]
        PaidVacation,

        [Display(Name = "Profit Sharing")]
        [UiInfo(Display = "Profit Sharing", Class = "money-bill")]
        ProfitSharing,

        [Display(Name = "Child Care")]
        [UiInfo(Display = "Child Care", Class = "baby")]
        ChildCare,

        [Display(Name = "Maternity/Paternity Leave")]
        [UiInfo(Display = "Maternity/Paternity Leave", Class = "baby-carriage")]
        MaternityPaternityLeave,

        [Display(Name = "Tuition Reimbursement")]
        [UiInfo(Display = "Tuition Reimbursement", Class = "graduation-cap")]
        TuitionReimbursement,

        [Display(Name = "Parking Reimbursement")]
        [UiInfo(Display = "Parking Reimbursement", Class = "parking")]
        ParkingReimbursement
    }
}