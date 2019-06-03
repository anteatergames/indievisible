using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.ViewModels.Brainstorm
{
    public class BrainstormVoteViewModel : BaseViewModel
    {
        public Guid VotingItemId { get; set; }

        public VoteValue VoteValue { get; set; }
    }
}
