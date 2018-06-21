using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloomingFlower.CustomHtmlHelper
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString DisplayImage(this HtmlHelper helper,string source,string altText,object htmlAttributes )
        {
            TagBuilder builder = new TagBuilder("img");
            builder.Attributes.Add("src", VirtualPathUtility.ToAbsolute(source));
            builder.Attributes.Add("alt", altText);
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}