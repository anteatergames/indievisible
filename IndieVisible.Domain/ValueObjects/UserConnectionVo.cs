using IndieVisible.Domain.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.ValueObjects
{
    public class UserConnectionVo
    {
        public bool Accepted { get; set; }

        public UserConnectionDirection? Direction { get; set; }

        public UserConnectionType ConnectionType { get; set; }
    }
}
