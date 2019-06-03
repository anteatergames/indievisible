using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Application.ViewModels.Brainstorm
{
    public class BrainstormCommentViewModel : BaseViewModel
    {
        public Guid? ParentCommentId { get; set; }

        public Guid IdeaId { get; set; }

        public string AuthorName { get; set; }

        public string AuthorPicture { get; set; }

        public string Text { get; set; }
    }
}
