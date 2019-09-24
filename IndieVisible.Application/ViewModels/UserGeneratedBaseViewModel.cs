using IndieVisible.Domain.Core.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IndieVisible.Application.ViewModels
{
    public abstract class UserGeneratedBaseViewModel : BaseViewModel
    {
        [Display(Name = "Author Picture")]
        public string AuthorPicture { get; set; }

        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }

        public UserContentType UserContentType { get; set; }

        protected UserGeneratedBaseViewModel() : base()
        {

        }
    }
    public abstract class UserGeneratedCommentBaseViewModel<TComment> : UserGeneratedBaseViewModel
    {
        public List<TComment> Comments { get; set; }

        protected UserGeneratedCommentBaseViewModel() : base()
        {
            Comments = new List<TComment>();
        }
    }


}
