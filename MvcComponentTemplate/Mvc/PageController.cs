using System.Web.Mvc;

namespace MvcComponentTemplate.Mvc
{
    /// <summary>
    /// Default controller for pages
    /// </summary>
    public class PageController : Controller
    {
        public PageController()
        {
            ActionInvoker = BaseControllerActionInvoker.CreateFor<PageController>("Index");
        }

        public virtual ActionResult Index()
        {
            return PageView();
        }

        protected virtual string GetViewName()
        {
            return RouteData.Values["action"].ToString();
        }

        protected virtual ActionResult PageView()
        {
            return View(GetViewName());
        }

        protected virtual ActionResult PageView(string viewName)
        {
            return View(viewName);
        }

        protected virtual ActionResult PageView<TModel>(TModel model)
        {
            return View(GetViewName(), model);
        }

        protected virtual ActionResult PageView<TModel>(string viewName, TModel model)
        {
            return View(viewName, model);
        }
    }
}