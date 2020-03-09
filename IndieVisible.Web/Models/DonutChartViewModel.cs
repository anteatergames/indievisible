namespace IndieVisible.Web.Models
{
    public class DonutChartViewModel
    {
        public double Percentage { get; set; }

        public double StrokeWidth { get; set; }

        public string Text { get; set; }

        public DonutChartViewModel(double percentage, string text)
        {
            Percentage = percentage;
            Text = text;
            StrokeWidth = 3.5;
        }

        public DonutChartViewModel(double percentage, string text, double strokeWidth)
        {
            Percentage = percentage;
            Text = text;
            StrokeWidth = strokeWidth;
        }
    }
}
