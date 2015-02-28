using System.Web.Mvc;

namespace MvcComponentTemplate.Mvc
{
    /// <summary>
    /// Custom Razor engine that replace the paths of the views
    /// </summary>
    public class ComponentRazorViewEngine : RazorViewEngine
    {
        private static readonly string[] ViewLocations = {
            "~/Pages/{1}/{0}/{0}.cshtml",
            "~/Pages/{1}/{0}.cshtml",
            "~/Pages/Shared/Views/{0}.cshtml",
            "~/Pages/Shared/{0}.cshtml"
        };

        private static readonly string[] MasterViewLocations = {  
            "~/Pages/Shared/Views/{0}.cshtml",
            "~/Pages/Shared/{0}.cshtml",
            "~/Pages/{1}/{0}/{0}.cshtml",
            "~/Pages/{1}/{0}.cshtml"
        };

        public ComponentRazorViewEngine()
        {
            PartialViewLocationFormats = ViewLocations;
            ViewLocationFormats = ViewLocations;
            MasterLocationFormats = MasterViewLocations;
            FileExtensions = new[] { "cshtml" };
        }
    }
}