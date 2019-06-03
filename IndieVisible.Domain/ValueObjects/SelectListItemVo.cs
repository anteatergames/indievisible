using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.ValueObjects
{
    public class SelectListItemVo
    {
        public string Value { get; set; }

        public string Text { get; set; }

        public bool Selected { get; set; }
    }
}
