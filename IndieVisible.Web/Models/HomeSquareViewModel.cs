using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Models
{
    public class HomeSquareViewModel
    {
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string ColorClass { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }

        public HomeSquareViewModel(string controller, string action, string colorClass, string icon, string text)
        {
            this.Area = string.Empty;
            this.Controller = controller;
            this.Action = action;
            this.ColorClass = colorClass;
            this.Icon = icon;
            this.Text = text;
        }
        public HomeSquareViewModel(string area, string controller, string action, string colorClass, string icon, string text)
        {
            this.Area = area;
            this.Controller = controller;
            this.Action = action;
            this.ColorClass = colorClass;
            this.Icon = icon;
            this.Text = text;
        }
    }
}
