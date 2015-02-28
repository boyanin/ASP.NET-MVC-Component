using System.Web.Routing;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString Component(this HtmlHelper html, string componentName)
        {
            return html.Component(componentName, null, null);
        }

        public static IHtmlString Component(this HtmlHelper html, string componentName, string pageName)
        {
            return html.Component(componentName, pageName, null);
        }

        public static IHtmlString Component(this HtmlHelper html, string componentName, object rotueValues)
        {
            return html.Component(componentName, null, rotueValues);
        }

        public static IHtmlString Component(this HtmlHelper html, string componentName, string pageName, RouteValueDictionary rotueValues)
        {
            return html.ComponentInternal(componentName, pageName, 
                rotueValues != null ? new RouteValueDictionary(rotueValues) : new RouteValueDictionary());
        }

        public static IHtmlString Component(this HtmlHelper html, string componentName, string pageName, object rotueValues)
        {
            return html.ComponentInternal(componentName, pageName, new RouteValueDictionary(rotueValues));
        }

        private static IHtmlString ComponentInternal(this HtmlHelper html, string componentName, string pageName, RouteValueDictionary rotueValues)
        {
            if (pageName != null)
            {
                rotueValues.Add("page", pageName);
            }
            return html.Action("Render", componentName, rotueValues);
        }
    }
}