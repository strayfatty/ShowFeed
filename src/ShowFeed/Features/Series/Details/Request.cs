using ShowFeed.Infrastructure;

namespace ShowFeed.Features.Series.Details
{
	public sealed class Request : IRequest<Response>
    {
		public Request(string seriesId)
		{
			this.SeriesId = seriesId;
		}

		public string SeriesId { get; set; }
    }
}
