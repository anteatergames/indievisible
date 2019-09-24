using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace IndieVisible.Web.TagHelpers
{
    [HtmlTargetElement("input", Attributes = ForAttributeName)]
    public class CustomInputTagHelper : InputTagHelper
    {
        private const string ForAttributeName = "asp-for";

        [HtmlAttributeName("asp-is-readonly")]
        public bool IsDisabled { set; get; }

        public CustomInputTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsDisabled)
            {
                output.Attributes.SetAttribute("readOnly", "readOnly");
            }
            base.Process(context, output);
        }
    }
}
