using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Models
{
    public class CarouselViewModel
    {
        public List<CarouselItemViewModel> Items { get; set; }
    }

    public class CarouselItemViewModel
    {
        public string Url { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
