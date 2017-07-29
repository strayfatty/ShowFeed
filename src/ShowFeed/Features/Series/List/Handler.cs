using System.Threading;
using System.Threading.Tasks;
using ShowFeed.Infrastructure;

namespace ShowFeed.Features.Series.List
{
	public sealed class Handler : IPagedRequestHandler<Request, Series>
	{
		public Task<PagedResponse<Series>> Handle(
			Request request,
			CancellationToken token)
		{
			var response = new PagedResponse<Series>();
			return Task.FromResult(response);
		}
	}
}
