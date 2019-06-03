using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Models
{
    public class GameListItemViewModel
    {
        public string ImageUrl { get; set; }

        public string DeveloperImageUrl { get; set; }

        public string Name { get; set; }

        public string Developer { get; set; }

        public string Price { get; set; }

        public List<string> Platforms { get; set; }
    }
}
