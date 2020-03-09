using IndieVisible.Domain.Interfaces.Models;
using System;

namespace IndieVisible.Application.ViewModels.Jobs
{
    public class JobApplicantViewModel : BaseViewModel, IUserProfileBasic
    {
        public Guid JobPositionId { get; set; }
        public string Email { get; set; }
        public string CoverLetter { get; set; }

        public string Name { get; set; }
        public string ProfileImageUrl { get; set; }
        public string CoverImageUrl { get; set; }
        public string Location { get; set; }
        public decimal Score { get; set; }
    }
}