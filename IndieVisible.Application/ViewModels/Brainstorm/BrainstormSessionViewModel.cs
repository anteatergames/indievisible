using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IndieVisible.Application.ViewModels.Brainstorm
{
    public class BrainstormSessionViewModel : BaseViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public BrainstormSessionType Type { get; set; }

        public Guid? TargetContextId { get; set; }
    }
}
