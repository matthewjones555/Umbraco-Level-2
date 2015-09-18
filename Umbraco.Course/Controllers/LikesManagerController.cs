using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Umbraco.Core.Models;
using Umbraco.Web.WebApi;

namespace Umbraco.Course.Controllers
{
    public class LikesManagerController : UmbracoAuthorizedApiController
    {
        [HttpGet]
        public IEnumerable<IRelation> GetAll(int id)
        {
            return Services.RelationService.GetByParentId(id);
        }

        [HttpPost]
        public HttpResponseMessage PostDeleteById(int id)
        {
            var relation = Services.RelationService.GetById(id);

            if (relation == null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, id);
            }

            Services.RelationService.Delete(relation);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}