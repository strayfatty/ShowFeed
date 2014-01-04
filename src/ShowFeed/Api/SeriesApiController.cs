namespace ShowFeed.Api
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using AutoMapper;

    using ShowFeed.Models;
    using ShowFeed.Services;

    using WebMatrix.WebData;

    /// <summary>
    /// The series API controller.
    /// </summary>
    public class SeriesApiController : ApiController
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
        /// Initializes a new instance of the <see cref="SeriesApiController"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        /// <param name="seriesService">The series service.</param>
        public SeriesApiController(IDatabase database, ISeriesService seriesService)
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
            var show = this.database.Query<Series>().FirstOrDefault(x => x.SeriesId == id);
            if (object.ReferenceEquals(show, null))
            {
                var seriesDetails = this.seriesService.GetDetails(id);
                show = Mapper.Map<Series>(seriesDetails.Series);
                show.Episodes = Mapper.Map<IEnumerable<IBaseEpisodeRecord>, ICollection<Episode>>(seriesDetails.Episodes);

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
            var show = this.database.Load<Series>(id);

            user.FollowedSeries.Remove(show);
            this.database.SaveChanges();
        }
    }
}