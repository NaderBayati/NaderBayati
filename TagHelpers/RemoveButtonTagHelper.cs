using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpers
{
    [HtmlTargetElement("Remove-Button", Attributes = LinkFor)]
    public class RemoveButtonTagHelper : TagHelper
    {
        private const string LinkFor = "asp-link";

        [HtmlAttributeName(LinkFor)]
        public string LinkAttribute { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            string content = $"<a href='{LinkAttribute}' class='btn btn-danger'><span class='fa fa-trash'></span></a>";
            output.Content.SetHtmlContent(content);
            base.Process(context, output);
        }

    }
}
