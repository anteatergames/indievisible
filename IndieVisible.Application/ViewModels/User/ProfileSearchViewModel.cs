using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels.User
{
    public class ProfileSearchViewModel : BaseViewModel
    {
        public string Name { get; set; }
    }
}
