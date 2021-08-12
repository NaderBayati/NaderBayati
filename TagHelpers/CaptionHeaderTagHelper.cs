using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpers
{
    [HtmlTargetElement("Caption-Header", Attributes = TitleFor)]
    [HtmlTargetElement("Caption-Header", Attributes = IconFor)]
    public class CaptionHeaderTagHelper : TagHelper
    {
        private const string TitleFor = "asp-title";
        [HtmlAttributeName("TitleFor")]
        public string TitleAttribute { get; set; }
        private const string IconFor = "asp-icon";
        [HtmlAttributeName("IconFor")]
        public string IconAttribute { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            string content = "";
            content += "<div class='row'>";
            content += "<div class='col-lg-12'>";
            content += $"<h2 ><span class='{IconAttribute}'></span>{TitleAttribute}‌</h2>";
            content += "<hr />";
            content += "</div>";
            content += "</div>";
            output.Content.SetHtmlContent(content);
            base.Process(context, output);
        }
    }
}
