using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Models
{
    public class Select2SearchResultViewModel
    {
        public List<Select2SearchResultItemViewModel> Results { get; set; }

        public Select2SearchResultPaginationViewModel Pagination { get; set; }

        public Select2SearchResultViewModel()
        {
            Results = new List<Select2SearchResultItemViewModel>();
            Pagination = new Select2SearchResultPaginationViewModel();
        }
    }
    public class Select2SearchResultItemViewModel
    {
        public string Id { get; set; }

        public string Text { get; set; }
    }
    public class Select2SearchResultPaginationViewModel
    {
        public bool More { get; set; }

        public Select2SearchResultPaginationViewModel()
        {
            More = false;
        }
    }
}
