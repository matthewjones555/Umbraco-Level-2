using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace Umbraco.Course.Models
{
    public class StreamModel : RenderModel
    {
        public StreamModel(IPublishedContent content, CultureInfo culture)
            : base(content, culture) { }

        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool IsLastPage { get; set; }
        public IEnumerable<IPublishedContent> StatusUpdates { get; set; }
    }
}