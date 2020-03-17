using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.ValueObjects
{
    public class InMemoryFileVo
    {
        public string FileName { get; set; }

        public byte[] Contents { get; set; }
    }
}
