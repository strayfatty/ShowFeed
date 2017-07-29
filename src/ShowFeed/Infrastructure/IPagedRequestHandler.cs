using System.Threading;
using System.Threading.Tasks;

namespace ShowFeed.Infrastructure
{
	public interface IPagedRequestHandler<TRequest, TItem>
		where TRequest : PagedRequest<TItem>
	{
		Task<PagedResponse<TItem>> Handle(TRequest request, CancellationToken token);
	}
}
