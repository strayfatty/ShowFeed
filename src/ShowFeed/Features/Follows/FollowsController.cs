using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShowFeed.Infrastructure;

namespace ShowFeed.Features.Follows
{
	[ApiController]
	[Route("api/follows")]
	public sealed class FollowsController : ControllerBase
    {
		private readonly IPagedRequestHandler<List.Request, Series.Series> list;

		private readonly IRequestHandler<Create.Request> create;

		private readonly IRequestHandler<Delete.Request> delete;

		public FollowsController(
			IPagedRequestHandler<List.Request, Series.Series> list,
			IRequestHandler<Create.Request> create,
			IRequestHandler<Delete.Request> delete)
		{
			this.list = list;
			this.create = create;
			this.delete = delete;
		}

		[HttpGet]
		[Route("")]
		public Task<PagedResponse<Series.Series>> List(
			[FromQuery(Name = "")]List.Request request)
		{
			return this.list.Handle(request, this.HttpContext.RequestAborted);
		}

		[HttpPut]
		[Route("{id}")]
		public Task Create(string id)
		{
			var request = new Create.Request(id);
			return this.create.Handle(request, this.HttpContext.RequestAborted);
		}

		[HttpDelete]
		[Route("{id}")]
		public Task Delete(string id)
		{
			var request = new Delete.Request(id);
			return this.delete.Handle(request, this.HttpContext.RequestAborted);
		}
    }
}
