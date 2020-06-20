using IndieVisible.Domain.Core.Enums;

namespace IndieVisible.Domain.ValueObjects
{
    public class UserConnectionVo
    {
        public bool Accepted { get; set; }

        public UserConnectionDirection? Direction { get; set; }

        public UserConnectionType ConnectionType { get; set; }
    }
}
