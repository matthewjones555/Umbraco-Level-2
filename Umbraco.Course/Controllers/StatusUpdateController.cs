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
            {
                return CurrentUmbracoPage();
            }

            string name = Umbraco.Truncate(Umbraco.StripHtml(model.BodyText), 50, false).ToString();

            var statusUpdate = Services.ContentService.CreateContent(name, CurrentPage.Id, "statusUpdate");

            statusUpdate.SetValue("bodyText", model.BodyText);

            var publishStatus = Services.ContentService.PublishWithStatus(statusUpdate);

            return RedirectToCurrentUmbracoPage();
        }
    }
}