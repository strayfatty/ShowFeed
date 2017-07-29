using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShowFeed.Infrastructure;

namespace ShowFeed.Features.Series
{
	[ApiController]
	[Route("api/series")]
	public sealed class SeriesController : ControllerBase
	{
		private readonly IPagedRequestHandler<List.Request, Series> list;

		private readonly IRequestHandler<Details.Request, Details.Response> details;

		public SeriesController(
			IPagedRequestHandler<List.Request, Series> list,
			IRequestHandler<Details.Request, Details.Response> details)
		{
			this.list = list;
			this.details = details;
		}

		[HttpGet]
		[Route("")]
		public Task<PagedResponse<Series>> List(
			[FromQuery(Name = "")]List.Request request)
		{
			return this.list.Handle(request, this.HttpContext.RequestAborted);
		}

		[HttpGet]
		[Route("{id}")]
		public Task<Details.Response> Details(string id)
		{
			var request = new Details.Request(id);
			return this.details.Handle(request, this.HttpContext.RequestAborted);
		}
	}
}
