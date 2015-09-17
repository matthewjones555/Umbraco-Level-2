using System.Linq;
using System.Web.Mvc;
using Umbraco.Course.Models;
using Umbraco.Web.Mvc;

namespace Umbraco.Course.Controllers
{
    public class SearchController : SurfaceController
    {
        [ChildActionOnly]
        public ActionResult Search(string query)
        {
       
            return null;
        }
    }
}
