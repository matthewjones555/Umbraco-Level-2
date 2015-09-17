using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Umbraco.Course.Models
{
    public class StatusUpdateModel
    {
        [Required]
        [DisplayName("Please post your update")]
        public string BodyText { get; set; }
        
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}