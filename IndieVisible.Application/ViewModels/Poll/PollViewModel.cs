using System;
using System.Collections.Generic;

namespace IndieVisible.Application.ViewModels.Poll
{
    public class PollViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public bool MultipleChoice { get; set; }

        public bool UsersCanAddOptions { get; set; }

        public DateTime? CloseDate { get; set; }

        public int TotalVotes { get; set; }

        public List<PollOptionViewModel> PollOptions { get; set; }

        public PollViewModel()
        {
            PollOptions = new List<PollOptionViewModel>();
        }
    }
}