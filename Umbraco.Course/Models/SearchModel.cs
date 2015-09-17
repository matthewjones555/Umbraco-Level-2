using System.Collections.Generic;
using Umbraco.Core.Models;

namespace Umbraco.Course.Models
{
    public class SearchModel
    {
        public string Query { get; set; }
	public IEnumerable<IPublishedContent> SearchResults { get; set; }
    }
}