using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Course.Level2;
using Umbraco.Course.Models;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace Umbraco.Course.Controllers
{
    public class StreamController : RenderMvcController
    {
        public ActionResult Index(RenderModel model, int page = 1)
        {
            var stream = new StreamModel(model.Content, model.CurrentCulture);
            stream.Page = page;
            Helper.PopulatePaging(stream);
            return CurrentTemplate(stream);
        }
    }
}