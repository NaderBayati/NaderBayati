using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpers
{
    [HtmlTargetElement("tbody", Attributes = "for")]
    public class TableCreatorTagHelper : TagHelper
    {
        [HtmlAttributeName("for")]
        public ModelExpression For { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "tbody";
            string str = "";
            foreach (var prop in For.Metadata.Properties)
            {
                str += "<tr>" + prop.PropertyGetter(prop) + "</tr>";
            }
            output.Content.SetHtmlContent(str);
            base.Process(context,output);
        }
    }
}
