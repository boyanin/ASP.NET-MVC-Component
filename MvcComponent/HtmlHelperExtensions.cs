using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MvcComponent
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlString ComponentFor<TController>(this HtmlHelper html)
            where TController : ComponentController
        {
            return html.Component(GetComponentName(typeof(TController)));
        }

        public static IHtmlString ComponentFor<TController>(this HtmlHelper html, string pageName)
            where TController : ComponentController
        {
            return html.Component(GetComponentName(typeof(TController)), pageName);
        }

        public static IHtmlString ComponentFor<TController>(this HtmlHelper html, RouteValueDictionary routeValues)
            where TController : ComponentController
        {
            return html.Component(GetComponentName(typeof(TController)), routeValues);
        }

        public static IHtmlString ComponentFor<TController>(this HtmlHelper html, object routeValues)
        where TController : ComponentController
        {
            return html.Component(GetComponentName(typeof(TController)), routeValues);
        }

        public static IHtmlString ComponentFor<TController>(this HtmlHelper html, string pageName, object routeValues)
          where TController : ComponentController
        {
            return html.Component(GetComponentName(typeof(TController)), pageName, routeValues);
        }

        public static IHtmlString ComponentFor<TController>(this HtmlHelper html, string pageName, RouteValueDictionary routeValues)
            where TController : ComponentController
        {
            return html.Component(GetComponentName(typeof(TController)), pageName, routeValues);
        }

        public static IHtmlString Component(this HtmlHelper html, string componentName)
        {
            return html.Component(componentName, null, null);
        }

        public static IHtmlString Component(this HtmlHelper html, string componentName, string pageName)
        {
            return html.Component(componentName, pageName, null);
        }

        public static IHtmlString Component(this HtmlHelper html, string componentName, RouteValueDictionary rotueValues)
        {
            return html.Component(componentName, null, rotueValues);
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

        private static string GetComponentName(Type componentControllerType)
        {
            return componentControllerType.Name.Replace("Controller", string.Empty);
        }
    }
}