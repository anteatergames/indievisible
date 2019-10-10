namespace IndieVisible.Web.Models
{
    public class ListNoItemsViewModel
    {
        public string MainClass { get; set; }
        public string Icon { get; set; }
        public string Text { get; set; }

        public ListNoItemsViewModel(string icon, string text)
        {
            Icon = icon;
            Text = text;
        }

        public ListNoItemsViewModel(string mainClass, string icon, string text)
        {
            MainClass = mainClass;
            Icon = icon;
            Text = text;
        }
    }
}
