using MvcComponentTemplate.Mvc;
using System.Web.Mvc;

namespace MvcComponentTemplate.Pages.Account
{
    public class AccountController : PageController
    {
        public ActionResult Index(string redirectTo)
        {
            return PageView(new AccountIndexModel { RedirectTo = redirectTo });
        }
    }
}