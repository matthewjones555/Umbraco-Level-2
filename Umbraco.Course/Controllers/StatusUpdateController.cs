using System;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Course.Level2;
using Umbraco.Course.Models;
using System.Collections.Generic;

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

            if (model.Files.HasFiles() && model.Files.ContainsImages())
            {
                string statusFolderName = "Status updates";
                var statusFolder = Services.MediaService.GetChildren(-1).FirstOrDefault(m => m.Name == statusFolderName);

                if (statusFolder == null)
                {
                    //create the folder for all of the status updates
                    statusFolder = Services.MediaService.CreateMedia(statusFolderName, -1, "Folder");
                    Services.MediaService.Save(statusFolder);
                }

                var folder = Services.MediaService.CreateMedia(Guid.NewGuid().ToString(), statusFolder.Id, "Folder");
                Services.MediaService.Save(folder);

                var ids = new List<string>();

                foreach (var file in model.Files.Where(f => f.IsImage()))
                {
                    var image = Services.MediaService.CreateMedia(file.FileName, folder.Id, "Image");
                    image.SetValue("umbracoFile", file);
                    Services.MediaService.Save(image);
                    ids.Add(image.Id.ToString());
                }

                string joinedIds = string.Join(",", ids);

                statusUpdate.SetValue("relatedMedia", joinedIds);
            }

            var publishStatus = Services.ContentService.PublishWithStatus(statusUpdate);

            return RedirectToCurrentUmbracoPage();
        }
    }
}