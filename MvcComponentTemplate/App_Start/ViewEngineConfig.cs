using MvcComponentTemplate.Mvc;
using System.Web.Mvc;

namespace MvcComponentTemplate
{
    public class ViewEngineConfig
    {
        public static void RegisterViewEngines(ViewEngineCollection viewEngines)
        {
            viewEngines.Clear();
            viewEngines.Add(new ComponentRazorViewEngine());
        }
    }
}
