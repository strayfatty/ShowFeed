using ShowFeed.Infrastructure;

namespace ShowFeed.Features.Series.List
{
	public sealed class Request : PagedRequest<Series>
    {
		public string Filter { get; set; }
    }
}
