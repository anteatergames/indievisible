using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndieVisible.Web.Models
{
    public class DonutChartViewModel
    {
        public double Percentage { get; set; }

        public double StrokeWidth { get; set; }

        public string Text { get; set; }

        public DonutChartViewModel(double percentage, string text)
        {
            StrokeWidth = 3.5;
        }

        public DonutChartViewModel(double percentage, string text, double strokeWidth)
        {
            this.Percentage = percentage;
            this.Text = text;
            this.StrokeWidth = strokeWidth;
        }
    }
}
