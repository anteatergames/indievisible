using IndieVisible.Domain.Core.Models;
using System;

namespace IndieVisible.Domain.Models
{
    public class UserContentLike : Entity
    {
        public Guid ContentId { get; set; }
    }
}
