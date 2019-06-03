using IndieVisible.Infra.CrossCutting.Identity.Models.AccountViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Models
{
    public class MvcExternalLoginViewModel : ExternalLoginViewModel
    {
        [Required(ErrorMessage = "The username is required")]
        [Remote("validateusername", "account", HttpMethod = "POST", ErrorMessage = "Oops! Someone already took that username!")]
        [Display(Name = "UserName")]
        [StringLength(64, ErrorMessage ="The username must have maximum 64 characters")]
        [RegularExpression("^(?=.{3,64}$)(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._-]+(?<![_.-])$", ErrorMessage = "Must have minimum 3 characters.</br>Must contain only letters, numbers, dashes, underscores and dots.</br>Must not contain two symbols in sequence.</br>Must not start or end with a symbol.")]
        public new string Username { get; set; }
    }
}
