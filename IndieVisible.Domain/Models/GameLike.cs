using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class GameLike : Entity
    {
        public Guid GameId { get; set; }
    }
}
