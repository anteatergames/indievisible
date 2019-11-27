using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Application.ViewModels.Brainstorm
{
    public class BrainstormVoteViewModel : BaseViewModel
    {
        public Guid VotingItemId { get; set; }

        public VoteValue VoteValue { get; set; }
    }
}