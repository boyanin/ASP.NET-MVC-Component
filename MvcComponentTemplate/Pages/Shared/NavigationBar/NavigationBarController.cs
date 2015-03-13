using MvcComponent;
using System.Web.Mvc;

namespace MvcComponentTemplate.Pages.Shared.NavigationBar
{
    public class NavigationBarController : ComponentController
    {
        [ChildActionOnly]
        public ActionResult Render(string url)
        {
            return ComponentView(new NavigationBarModel { Url = url });
        }
    }
}