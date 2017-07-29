using ShowFeed.Infrastructure;

namespace ShowFeed.Features.Follows.Create
{
	public sealed class Request : IRequest
	{
		public Request(string seriesId)
		{
			this.SeriesId = seriesId;
		}

		public string SeriesId { get; set; }
	}
}
