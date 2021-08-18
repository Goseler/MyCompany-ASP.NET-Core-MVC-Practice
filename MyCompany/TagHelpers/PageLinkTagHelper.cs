using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MyCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory _urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
		{
            _urlHelperFactory = urlHelperFactory;
		}

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageViewModel PageModel { get; set; }
        public string PageAction { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";

            TagBuilder tag = new("ul");
            tag.AddCssClass("pagination");

            TagBuilder currentItem = CreateTag(PageModel.PageNumber, urlHelper);

			if (PageModel.HasPreviousPage)
			{
                TagBuilder prevItem = CreateTag(PageModel.PageNumber - 1, urlHelper);
                tag.InnerHtml.AppendHtml(prevItem);
			}

            tag.InnerHtml.AppendHtml(currentItem);

			if (PageModel.HasNextPage)
			{
                TagBuilder nextItem = CreateTag(PageModel.PageNumber + 1, urlHelper);
                tag.InnerHtml.AppendHtml(nextItem);
			}
            output.Content.AppendHtml(tag);
		}

		private TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
		{
            TagBuilder item = new("li");
            TagBuilder link = new("a");
            if(pageNumber == this.PageModel.PageNumber)
			{
                item.AddCssClass("active");
			}
			else
			{
                link.Attributes["href"] = urlHelper.Action(PageAction, new { page = pageNumber });
			}
            item.AddCssClass("page-item");
            link.AddCssClass("page-link");
            link.InnerHtml.Append(pageNumber.ToString());
            item.InnerHtml.AppendHtml(link);
            return item;
		}
	}
}
