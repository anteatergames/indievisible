using IndieVisible.Domain.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels.Brainstorm
{
    public class BrainstormSessionViewModel : BaseViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Type")]
        public BrainstormSessionType Type { get; set; }

        public Guid? TargetContextId { get; set; }
    }
}
