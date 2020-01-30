using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.ViewModels.Jobs
{
    public class JobApplicantViewModel : BaseViewModel
    {
        public string CoverLetter { get; set; }
        public string Name { get; internal set; }
    }
}
