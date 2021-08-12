using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpers
{
    [HtmlTargetElement("Edit-Button", Attributes = LinkFor)]
    public class EditButtonTagHelper : TagHelper
    {
        private const string LinkFor = "asp-link";

        [HtmlAttributeName(LinkFor)]
        public string LinkAttribute { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            string content = $"<a href='{LinkAttribute}' class='btn btn-warning text-white'><span class='fa fa-edit'></span></a>";
            output.Content.SetHtmlContent(content);
            base.Process(context, output);
        }
    }
}
