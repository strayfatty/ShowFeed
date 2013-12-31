﻿namespace ShowFeed.Api
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
        /// The series service.
        /// </summary>
        private readonly ISeriesService seriesService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TvShowsApiController"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="seriesService">The series service.</param>
        public TvShowsApiController(IDatabase database, ISeriesService seriesService)
        {
            this.database = database;
            this.seriesService = seriesService;
        }

        /// <summary>
        /// Makes the current user follow the show and adds the show
        /// to the database if it is not already present.
        /// </summary>
        /// <param name="id">The show id.</param>
        [HttpPut]
        public void Put(int id)
        {
            ////var show = this.database.Query<Series>().FirstOrDefault(x => x.SeriesId == id);
            ////if (object.ReferenceEquals(show, null))
            ////{
            ////    show = this.seriesService.GetDetails(id);
            ////    this.database.Store(show);
            ////}

            ////show.Followers.Add(this.database.Query<User>().First(x => x.Username == WebSecurity.CurrentUserName));
            ////this.database.SaveChanges();
        }

        /// <summary>
        /// Makes the current user no longer follow the show.
        /// </summary>
        /// <param name="id">The id of the show.</param>
        [HttpDelete]
        public void Delete(int id)
        {
            ////var user = this.database.Query<User>().First(x => x.Username == WebSecurity.CurrentUserName);
            ////var show = this.database.Load<Series>(id);

            ////user.FollowedSeries.Remove(show);
            ////this.database.SaveChanges();
        }
    }
}