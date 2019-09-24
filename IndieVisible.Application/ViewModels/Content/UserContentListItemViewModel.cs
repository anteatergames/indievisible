using IndieVisible.Application.ViewModels.Poll;
using IndieVisible.Domain.Core.Enums;
using System;
using System.Linq;

namespace IndieVisible.Application.ViewModels.Content
{
    public class UserContentListItemViewModel : UserGeneratedCommentBaseViewModel<UserContentCommentViewModel>
    {
        public string FeaturedImage { get; set; }

        public string Title { get; set; }

        public string Introduction { get; set; }

        public string Content { get; set; }

        public SupportedLanguage Language { get; set; }

        public int LikeCount { get; set; }

        public int CommentCount { get; set; }

        public Guid GameId { get; set; }

        public string GameName { get; set; }

        public bool IsArticle { get; set; }

        public bool HasFeaturedImage { get; set; }

        public MediaType FeaturedImageType { get; set; }

        public bool HasPoll { get { return this.Poll != null && this.Poll.PollOptions.Any(); } }

        public PollViewModel Poll { get; set; }
    }
}
