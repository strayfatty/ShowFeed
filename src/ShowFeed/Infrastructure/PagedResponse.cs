using System.Collections.Generic;
using System.Linq;

namespace ShowFeed.Infrastructure
{
	public sealed class PagedResponse<T>
	{
		public PagedResponse()
			: this(Enumerable.Empty<T>())
		{
		}

		public PagedResponse(IEnumerable<T> items)
		{
			this.Items = items;
		}

		public IEnumerable<T> Items { get; set; }
	}
}
