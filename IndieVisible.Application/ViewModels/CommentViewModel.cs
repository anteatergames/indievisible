using System;

namespace IndieVisible.Application.ViewModels
{
    public class CommentViewModel : UserGeneratedBaseViewModel
    {
        public Guid ParentCommentId { get; set; }

        public Guid UserContentId { get; set; }

        public string Text { get; set; }
    }
}