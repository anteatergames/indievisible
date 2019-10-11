using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Application.ViewModels.User
{
    public class UserProfileExternalLinkViewModel : BaseViewModel
    {
        public Guid UserProfileId { get; set; }

        public ExternalLinkType Type { get; set; }

        public ExternalLinkProvider Provider { get; set; }

        public string Value { get; set; }

        public string UiClass { get; set; }
        public string Display { get; set; }
    }
}
