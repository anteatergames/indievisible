using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels
{
    public abstract class UserGeneratedBaseViewModel : BaseViewModel, IUserGeneratedContent
    {
        [Display(Name = "Author Picture")]
        public string AuthorPicture { get; set; }

        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }

        public UserContentType UserContentType { get; set; }

        public string ShareUrl { get; set; }

        public string ShareText { get; set; }

        protected UserGeneratedBaseViewModel() : base()
        {
        }
    }

    public abstract class UserGeneratedCommentBaseViewModel : UserGeneratedBaseViewModel
    {
        public List<CommentViewModel> Comments { get; set; }

        public List<Guid> Likes { get; set; }

        public string Url { get; set; }

        [Display(Name = "Language")]
        public SupportedLanguage Language { get; set; }

        private int likeCount;

        public int LikeCount
        {
            get
            {
                if (likeCount == 0)
                {
                    return Likes.Count;
                }

                return likeCount;
            }
            set
            {
                likeCount = value;
            }
        }

        private int commentCount;

        [Display(Name = "Comment Count")]
        public int CommentCount
        {
            get
            {
                if (commentCount == 0)
                {
                    return Comments.Count;
                }

                return commentCount;
            }
            set
            {
                commentCount = value;
            }
        }

        protected UserGeneratedCommentBaseViewModel() : base()
        {
            Comments = new List<CommentViewModel>();
            Likes = new List<Guid>();
        }
    }
}