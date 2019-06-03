using IndieVisible.Application.ViewModels.FeaturedContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Application.ViewModels.Home
{
    public class CarouselViewModel
    {
        public List<FeaturedContentViewModel> Items { get; set; }
    }
}
