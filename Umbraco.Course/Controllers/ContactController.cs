using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Course.Models;
using Umbraco.Web.Mvc;

namespace Umbraco.Course.Controllers
{
    public class ContactController : SurfaceController
    {
        [HttpPost]
        public ActionResult Submit(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                SaveMessage(model);
                TempData["Success"] = true;
                return RedirectToCurrentUmbracoPage();
            }

            return CurrentUmbracoPage();
        }

        private void SaveMessage(ContactModel model)
        {
            //TODO: Save message
        }
    }
}
