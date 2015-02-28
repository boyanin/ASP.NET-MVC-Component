using MvcComponentTemplate.Mvc;
using System.Web.Mvc;

namespace MvcComponentTemplate
{
    public class ControllerConfig
    {
        public static void RegisterControllerFactory(ControllerBuilder builder)
        {
            builder.SetControllerFactory(new CustomControllerFactory());
        }
    }
}
