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
            Area = string.Empty;
            Controller = controller;
            Action = action;
            ColorClass = colorClass;
            Icon = icon;
            Text = text;
        }

        public HomeSquareViewModel(string area, string controller, string action, string colorClass, string icon, string text)
        {
            Area = area;
            Controller = controller;
            Action = action;
            ColorClass = colorClass;
            Icon = icon;
            Text = text;
        }
    }
}