using IndieVisible.Domain.Core.Enums;
using IndieVisible.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IndieVisible.Domain.Models
{
    public class UserProfile : ExternalEntity
    {
        public ProfileType Type { get; set; }

        public string Name { get; set; }

        public string Motto { get; set; }

        public string Bio { get; set; }

        public string StudioName { get; set; }

        public string Location { get; set; }
    }
}
