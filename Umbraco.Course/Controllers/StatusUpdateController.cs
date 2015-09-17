using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Course.Level2;
using Umbraco.Course.Models;

namespace Umbraco.Course.Controllers
{
    public class StatusUpdateController : SurfaceController
    {
        public ActionResult Create(StatusUpdateModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();
            
            return RedirectToCurrentUmbracoPage();
        }
    }
}