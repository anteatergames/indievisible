using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Infra.CrossCutting.Identity.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}