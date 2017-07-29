using ShowFeed.Infrastructure;

namespace ShowFeed.Features.Follows.List
{
	public sealed class Request : PagedRequest<Series.Series>
	{
		public string Filter { get; set; }
	}
}
