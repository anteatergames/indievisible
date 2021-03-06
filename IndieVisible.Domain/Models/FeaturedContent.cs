﻿using IndieVisible.Domain.Core.Models;
using System;

namespace IndieVisible.Domain.Models
{
    public class FeaturedContent : Entity
    {
        public Guid OriginalUserId { get; set; }

        public Guid UserContentId { get; set; }

        public bool Active { get; set; }

        public string Title { get; set; }

        public string Introduction { get; set; }

        public string FeaturedImage { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string ImageUrl { get; set; }
    }
}