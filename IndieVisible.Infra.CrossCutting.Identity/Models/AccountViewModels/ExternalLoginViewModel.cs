using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required(ErrorMessage = "The username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        public bool UserExists { get; set; }
    }
}