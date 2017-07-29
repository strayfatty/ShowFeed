using System.Threading;
using System.Threading.Tasks;
using ShowFeed.Infrastructure;

namespace ShowFeed.Features.Episodes.List
{
	public sealed class Handler : IPagedRequestHandler<Request, Episode>
	{
		public Task<PagedResponse<Episode>> Handle(Request request, CancellationToken token)
		{
			var response = new PagedResponse<Episode>();
			return Task.FromResult(response);
		}
	}
}
