using IndieVisible.Application.ViewModels;
using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;

namespace IndieVisible.Application.Interfaces
{
    public interface ICommentableItem
    {
        Guid Id { get; set; }

        UserContentType UserContentType { get; set; }

        string Url { get; set; }

        string Title { get; set; }

        SupportedLanguage Language { get; set; }

        bool CurrentUserLiked { get; set; }

        List<CommentViewModel> Comments { get; set; }

        int LikeCount { get; set; }

        int CommentCount { get; set; }
    }
}