using System;

namespace IndieVisible.Application.ViewModels.Content
{
    public class UserContentCommentViewModel : UserGeneratedBaseViewModel
    {
        public Guid ParentCommentId { get; set; }

        public Guid UserContentId { get; set; }

        public string Text { get; set; }
    }
}