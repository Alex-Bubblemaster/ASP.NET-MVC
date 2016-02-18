namespace SpecTester.Web.Infrastructure.Helpers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public static class HtmlExtensions
    {
        public static MvcHtmlString Submit(this HtmlHelper helper, string value, object htmlAttributes = null)
        {
            var input = new TagBuilder("input");
            input.Attributes.Add("type", "submit");
            input.Attributes.Add("value", value);
            input.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) as IDictionary<string, object>);
            input.AddCssClass("btn btn-dark");
            return new MvcHtmlString(input.ToString());
        }
    }
}
