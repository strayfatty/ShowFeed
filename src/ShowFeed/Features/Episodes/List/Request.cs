using ShowFeed.Infrastructure;

namespace ShowFeed.Features.Episodes.List
{
	public sealed class Request : PagedRequest<Episode>
    {
		public string SeriesId { get; set; }

		public int? Season { get; set; }
    }
}
