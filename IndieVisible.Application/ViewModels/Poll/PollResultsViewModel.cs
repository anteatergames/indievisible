using System;
using System.Collections.Generic;

namespace IndieVisible.Application.ViewModels.Poll
{
    public class PollResultsViewModel
    {
        public List<PollOptionResultsViewModel> OptionResults { get; set; }
        public int TotalVotes { get; set; }

        public PollResultsViewModel()
        {
            OptionResults = new List<PollOptionResultsViewModel>();
        }
    }
    public class PollOptionResultsViewModel
    {
        public Guid OptionId { get; set; }

        public int VoteCount { get; set; }

        public string Percentage { get; set; }
    }
}
