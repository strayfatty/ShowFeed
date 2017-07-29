using System.Threading;
using System.Threading.Tasks;
using ShowFeed.Infrastructure;

namespace ShowFeed.Features.Follows.Delete
{
	public sealed class Handler : IRequestHandler<Request>
	{
		public Task Handle(Request request, CancellationToken token)
		{
			return Task.CompletedTask;
		}
	}
}
