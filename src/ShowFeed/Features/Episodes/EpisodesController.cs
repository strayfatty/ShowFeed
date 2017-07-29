using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShowFeed.Infrastructure;

namespace ShowFeed.Features.Episodes
{
	[ApiController]
	[Route("api/episodes")]
	public sealed class EpisodesController : ControllerBase
	{
		private readonly IPagedRequestHandler<List.Request, Episode> list;

		public EpisodesController(
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
