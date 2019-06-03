using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.ViewModels.Content
{
    public class UserContentCommentViewModel : UserGeneratedBaseViewModel
    {
        public Guid ParentCommentId { get; set; }

        public Guid UserContentId { get; set; }

        public string Text { get; set; }
    }
}
