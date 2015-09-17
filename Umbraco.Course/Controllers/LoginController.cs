using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Umbraco.Course.Controllers
{
    public class LoginController : SurfaceController
    {
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            return CurrentUmbracoPage();
        }

        public ActionResult Logout()
        {
            return Redirect("/");
        }
    }
}
