using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpers
{
    [HtmlTargetElement("CreateNew-Button", Attributes = LinkFor)]
    public class CreateNewButtonTagHelper : TagHelper
    {
        private const string LinkFor = "asp-link";

        [HtmlAttributeName(LinkFor)]
        public string LinkAttribute { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            string content = $" <a href='{LinkAttribute}' class='btn btn-success'><span class='fa fa-plus'></span>&nbsp;ثبت جدید</a>";
            output.Content.SetHtmlContent(content);
            base.Process(context, output);
        }
    }
}
