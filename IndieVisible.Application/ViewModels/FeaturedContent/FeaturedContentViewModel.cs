using System;

namespace IndieVisible.Application.ViewModels.FeaturedContent
{
    public class FeaturedContentViewModel : BaseViewModel
    {
        public bool Active { get; set; }

        public Guid UserContentId { get; set; }

        public string Title { get; set; }

        public string Introduction { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Url { get; set; }

        public string ImageUrl { get; set; }
    }
}