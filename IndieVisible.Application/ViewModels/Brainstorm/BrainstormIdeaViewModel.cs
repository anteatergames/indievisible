using IndieVisible.Domain.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels.Brainstorm
{
    public class BrainstormIdeaViewModel : UserGeneratedCommentBaseViewModel<BrainstormCommentViewModel>
    {
        public Guid SessionId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int VoteCount { get; set; }

        public int CommentCount { get; set; }

        public int Score { get; internal set; }

        public VoteValue CurrentUserVote { get; set; }
    }
}
