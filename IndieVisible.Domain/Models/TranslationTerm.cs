using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class TranslationTerm : Entity
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public string Obs{ get; set; }
    }
}
