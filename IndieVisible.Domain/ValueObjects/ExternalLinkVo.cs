using IndieVisible.Domain.Core.Enums;

namespace IndieVisible.Domain.ValueObjects
{
    public class ExternalLinkVo
    {
        public ExternalLinkType Type { get; set; }

        public ExternalLinkProvider Provider { get; set; }

        public string Value { get; set; }
    }
}