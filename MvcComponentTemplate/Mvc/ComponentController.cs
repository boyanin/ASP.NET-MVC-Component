using System.Web.Mvc;

namespace MvcComponentTemplate.Mvc
{
    /// <summary>
    /// The base class for creating components. Every component should define a method, called
    /// Render. If a component wants to define some parameters in that method, it can define
    /// a new one.
    /// </summary>
    public class ComponentController : Controller
    {
        public ComponentController()
        {
            ActionInvoker = BaseControllerActionInvoker.CreateFor<ComponentController>("Render");
        }

        [ChildActionOnly]
        public virtual ActionResult Render()
        {
            return ComponentView();
        }

        protected virtual ActionResult ComponentView()
        {
            return PartialView(GetViewPath());
        }

        protected virtual ActionResult ComponentView<TModel>(TModel model)
        {
            return PartialView(GetViewPath(), model);
        }

        protected virtual string GetViewPath()
        {
            string page = RouteData.Values.ContainsKey("page") ? RouteData.Values["page"].ToString() : "Shared";
            string controllerName = RouteData.Values["controller"].ToString();
            return string.Format("~/Pages/{0}/{1}/{1}.cshtml", page, controllerName);
        }
    }
}