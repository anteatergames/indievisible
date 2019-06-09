using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.ValueObjects
{
    public class PermissionsVo
    {
        public bool CanEdit { get; set; }

        public bool CanPostActivity { get; set; }

        public bool CanFollow { get; set; }

        public bool CanConnect { get; set; }
    }
}
