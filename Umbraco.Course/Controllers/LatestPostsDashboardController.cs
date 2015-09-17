using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Umbraco.Web.WebApi;

namespace Umbraco.Course.Controllers
{
    public class LatestPostsDashboardController : UmbracoAuthorizedApiController
    {
        public IEnumerable<StatusUpdate> GetLatestsPost()
        {
        
            return null;
        }

    }

    public class StatusUpdate
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("memberName")]
        public string MemberName { get; set; }
        [JsonProperty("createDate")]
        public string CreateDate { get; set; }
    }
}