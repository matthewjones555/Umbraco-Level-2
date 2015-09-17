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

                var member = Services.MemberService.GetById(Members.GetCurrentMemberId());
                
                if (!Services.RelationService.AreRelated(post, member, "likes"))
                {
                    Services.RelationService.Relate(post, member, "likes");
                }

                int likes = Services.RelationService.GetByParent(post, "likes").Count();
                
                post.SetValue("likes", likes);
                Services.ContentService.PublishWithStatus(post);            

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, likes);
            }
        }
    }
}