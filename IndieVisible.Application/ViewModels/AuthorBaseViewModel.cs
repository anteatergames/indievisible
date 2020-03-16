using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels
{
    public class AuthorBaseViewModel
    {
        public Guid UserId { get; set; }

        [Display(Name = "Author Picture")]
        public string AuthorPicture { get; set; }

        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }

        public AuthorBaseViewModel() : base()
        {
        }

        public AuthorBaseViewModel(Guid userId)
        {
            UserId = userId;
        }
    }
}