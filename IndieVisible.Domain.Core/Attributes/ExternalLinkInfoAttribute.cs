using IndieVisible.Domain.Core.Enums;
using System;

namespace IndieVisible.Domain.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ExternalLinkInfoAttribute : UiInfoAttribute
    {
        public ExternalLinkType Type { get; set; }
        public bool IsStore { get; set; }
        public string ColorClass { get; set; }
    }
}