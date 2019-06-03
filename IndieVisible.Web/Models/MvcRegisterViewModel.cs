using IndieVisible.Infra.CrossCutting.Identity.Models.AccountViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Models
{
    public class MvcRegisterViewModel : RegisterViewModel
    {
        [Required(ErrorMessage = "The username is required")]
        [Remote("validateusername", "account", HttpMethod = "POST", ErrorMessage = "Oops! Someone already took that username!")]
        [Display(Name = "User Name")]
        public new string UserName { get; set; }
    }
}
