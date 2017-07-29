using System.Threading;
using System.Threading.Tasks;

namespace ShowFeed.Infrastructure
{
	public interface IRequestHandler<TRequest>
		where TRequest : IRequest
	{
		Task Handle(TRequest request, CancellationToken token);
	}


	public interface IRequestHandler<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
	{
		Task<TResponse> Handle(TRequest request, CancellationToken token);
	}
}
