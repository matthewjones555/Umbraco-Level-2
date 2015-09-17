using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Umbraco.Web.WebApi;

namespace Umbraco.Course.Controllers
{
    [MemberAuthorize(AllowType = "IntranetMember")]
    public class LikesController : UmbracoApiController
    {
        private static object likesStatusLock = new object();

        [HttpGet]
        public HttpResponseMessage LikeStatus(int id)
        {
            lock (likesStatusLock)
            {
                var post = Services.ContentService.GetById(id);

                if (post == null)
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                }

                int likes = post.GetValue<int>("likes");
                likes = likes + 1;

                post.SetValue("likes", likes);
                Services.ContentService.PublishWithStatus(post);            

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, likes);
            }
        }
    }
}