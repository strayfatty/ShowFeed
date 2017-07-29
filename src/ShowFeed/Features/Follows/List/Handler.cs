using System.Threading;
using System.Threading.Tasks;
using ShowFeed.Infrastructure;

namespace ShowFeed.Features.Follows.List
{
	public sealed class Handler : IPagedRequestHandler<Request, Series.Series>
	{
		public Task<PagedResponse<Series.Series>> Handle(
			Request request,
			CancellationToken token)
		{
			var response = new PagedResponse<Series.Series>();
			return Task.FromResult(response);
		}
	}
}
