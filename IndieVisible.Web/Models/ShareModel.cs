using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Models
{
    public class ShareModel
    {
        public string Url { get; set; }

        public string Text { get; set; }

        public ShareModel(string url)
        {
            this.Url = url;
        }

        public ShareModel(string url, string text) : this(url)
        {
            this.Text = text;
        }

    }
}
