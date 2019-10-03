using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Models
{
    public class ListNoItemsViewModel
    {
        public string MainClass { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }

        public ListNoItemsViewModel(string icon, string text)
        {
            this.Icon = icon;
            this.Text = text;
        }

        public ListNoItemsViewModel(string mainClass, string icon, string text)
        {
            this.MainClass = mainClass;
            this.Icon = icon;
            this.Text = text;
        }
    }
}
