using System.Threading;
using System.Threading.Tasks;
using ShowFeed.Infrastructure;

namespace ShowFeed.Features.Series.Details
{
	public sealed class Handler : IRequestHandler<Request, Response>
	{
		public Task<Response> Handle(Request request, CancellationToken token)
		{
			var series = new Series { SeriesId = request.SeriesId };
			return Task.FromResult(new Response(series));
		}
	}
}
