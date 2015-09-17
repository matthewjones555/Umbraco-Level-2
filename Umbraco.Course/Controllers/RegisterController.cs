using System.Web.Mvc;
using Umbraco.Course.Models;
using Umbraco.Web.Mvc;

namespace Umbraco.Course.Controllers
{
    public class RegisterController : SurfaceController
    {
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();
            
            

            return Redirect("/");
        }
    }
}
