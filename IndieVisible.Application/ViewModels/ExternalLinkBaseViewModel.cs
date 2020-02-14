using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Application.ViewModels
{
    public class ExternalLinkBaseViewModel
    {
        public Guid EntityId { get; set; }

        public int Order { get; set; }

        public ExternalLinkType Type { get; set; }

        public ExternalLinkProvider Provider { get; set; }

        public string Value { get; set; }

        public string IconClass { get; set; }

        public string ColorClass { get; set; }

        public string Display { get; set; }

        public bool IsStore { get; set; }
    }
}