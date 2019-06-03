using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class FeaturedContent : Entity
    {
        public bool Active { get; set; }

        public Guid UserContentId { get; set; }

        public string Title { get; set; }

        public string Introduction { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ImageUrl { get; set; }
    }
}
