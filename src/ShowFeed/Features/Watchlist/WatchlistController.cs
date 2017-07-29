using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShowFeed.Features.Episodes;
using ShowFeed.Infrastructure;

namespace ShowFeed.Features.Watchlist
{
	[ApiController]
	[Route("api/watchlist")]
	public sealed class WatchlistController : ControllerBase
	{
		private readonly IPagedRequestHandler<List.Request, Episode> list;

		public WatchlistController(
			IPagedRequestHandler<List.Request, Episode> list)
		{
			this.list = list;
		}

		[HttpGet]
		[Route("")]
		public Task<PagedResponse<Episode>> List(
			[FromQuery(Name = "")]List.Request request)
		{
			return this.list.Handle(request, this.HttpContext.RequestAborted);
		}
	}
}
