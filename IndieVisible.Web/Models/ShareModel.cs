namespace IndieVisible.Web.Models
{
    public class ShareModel
    {
        public string Url { get; set; }

        public string Text { get; set; }

        public ShareModel(string url)
        {
            Url = url;
        }

        public ShareModel(string url, string text) : this(url)
        {
            Text = text;
        }

    }
}
