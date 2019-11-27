using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The username is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}