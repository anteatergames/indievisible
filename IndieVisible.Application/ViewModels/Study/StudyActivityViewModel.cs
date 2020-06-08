using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.ViewModels.Study
{
    public class StudyActivityViewModel : BaseViewModel
    {
        public Guid ActivityId { get; set; }

        public int Order { get; set; }
    }
}
