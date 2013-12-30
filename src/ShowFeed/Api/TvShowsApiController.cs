namespace ShowFeed.Api
{
    using System.Linq;
    using System.Web.Http;

    using ShowFeed.Models;
    using ShowFeed.Services;

    using WebMatrix.WebData;

    /// <summary>
    /// The TV shows API controller.
    /// </summary>
    public class TvShowsApiController : ApiController
    {
        /// <summary>
        /// The database.
        /// </summary>
        private readonly IDatabase database;

        /// <summary>
        /// The TV show service.
        /// </summary>
        private readonly ITvShowService tvShowService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TvShowsApiController"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="tvShowService">The TV Show Service.</param>
        public TvShowsApiController(IDatabase database, ITvShowService tvShowService)
        {
            this.database = database;
            this.tvShowService = tvShowService;
        }

        /// <summary>
        /// Makes the current user follow the show and adds the show
        /// to the database if it is not already present.
        /// </summary>
        /// <param name="id">The show id.</param>
        [HttpPut]
        public void Put(int id)
        {
            var show = this.database.Query<TvShow>().FirstOrDefault(x => x.SourceId == id);
            if (object.ReferenceEquals(show, null))
            {
                show = this.tvShowService.GetDetails(id);
                this.database.Store(show);
            }

            show.Followers.Add(this.database.Query<User>().First(x => x.Username == WebSecurity.CurrentUserName));
            this.database.SaveChanges();
        }

        /// <summary>
        /// Makes the current user no longer follow the show.
        /// </summary>
        /// <param name="id">The id of the show.</param>
        [HttpDelete]
        public void Delete(int id)
        {
            var user = this.database.Query<User>().First(x => x.Username == WebSecurity.CurrentUserName);
            var show = this.database.Load<TvShow>(id);

            user.TvShowsFollowing.Remove(show);
            this.database.SaveChanges();
        }
    }
}