using IndieVisible.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.ViewModels.Jobs
{
    public class JobApplicantViewModel : BaseViewModel, IUserProfileBasic
    {
        public string CoverLetter { get; set; }
        public string Name { get; set; }
        public string ProfileImageUrl { get; set; }
        public string CoverImageUrl { get; set; }
        public string Location { get; set; }
    }
}
