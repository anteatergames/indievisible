using IndieVisible.Domain.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels.Brainstorm
{
    public class BrainstormIdeaViewModel : UserGeneratedCommentBaseViewModel<BrainstormCommentViewModel>
    {
        public Guid SessionId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Vote Count")]
        public int VoteCount { get; set; }

        [Display(Name = "Comment Count")]
        public int CommentCount { get; set; }

        [Display(Name = "Score")]
        public int Score { get; internal set; }

        public VoteValue CurrentUserVote { get; set; }

        public BrainstormIdeaStatus Status { get; set; }
    }
}
