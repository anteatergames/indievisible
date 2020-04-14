using IndieVisible.Domain.Core.Models;

namespace IndieVisible.Domain.Models
{
    public class LocalizationTerm : Entity
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public string Obs { get; set; }
    }
}