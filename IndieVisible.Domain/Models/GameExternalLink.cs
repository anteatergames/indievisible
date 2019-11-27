using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;

namespace IndieVisible.Domain.Models
{
    public class GameExternalLink : Entity
    {
        public Guid GameId { get; set; }

        public ExternalLinkType Type { get; set; }

        public ExternalLinkProvider Provider { get; set; }

        public string Value { get; set; }
    }
}