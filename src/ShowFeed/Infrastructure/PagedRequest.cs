using System;

namespace ShowFeed.Infrastructure
{
	public abstract class PagedRequest<T> : IRequest<PagedResponse<T>>
	{
		private int skip;

		private int take;

		protected PagedRequest()
			: this(0, 10)
		{
		}

		protected PagedRequest(int skip, int take)
		{
			this.Skip = skip;
			this.Take = take;
		}

		public int Skip
		{
			get => this.skip;

			set
			{
				this.skip = Math.Max(0, value);
			}
		}

		public int Take
		{
			get => this.take;

			set
			{
				this.take = Math.Max(1, Math.Min(value, 100));
			}
		}
	}
}
