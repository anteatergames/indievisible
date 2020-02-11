using IndieVisible.Domain.Core.Models;

namespace IndieVisible.Domain.Models
{
    public class JobApplicant : Entity
    {
        public string CoverLetter { get; set; }

        public decimal Score { get; set; }

        public string Email { get; set; }
    }
}