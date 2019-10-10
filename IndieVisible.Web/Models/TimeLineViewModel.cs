using System;
using System.Collections.Generic;

namespace IndieVisible.Web.Models
{
    public class TimeLineViewModel
    {
        public List<TimeLineItemViewModel> Items { get; set; }

        public TimeLineViewModel()
        {
            Items = new List<TimeLineItemViewModel>();
        }
    }
    public class TimeLineItemViewModel
    {
        public bool Start { get; set; }

        public bool End { get; set; }

        public DateTime Date { get; set; }

        public string Icon { get; set; }

        public string Color { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Description { get; set; }

        public List<String> Items { get; set; }

        public bool Future { get { return Date > DateTime.Today; } }

        public TimeLineItemViewModel()
        {
            Items = new List<string>();
            Icon = "far fa-calendar";
        }
    }
}
