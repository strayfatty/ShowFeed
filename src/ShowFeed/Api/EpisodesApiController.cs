namespace ShowFeed.Api
{
    using System.Linq;
    using System.Web.Http;

    using ShowFeed.Models;

    using WebMatrix.WebData;

    /// <summary>
    /// The episodes API controller.
    /// </summary>
    public class EpisodesApiController : ApiController
    {
        /// <summary>
        /// The database.
        /// </summary>
        private readonly IDatabase database;

        /// <summary>
        /// Initializes a new instance of the <see cref="EpisodesApiController"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public EpisodesApiController(IDatabase database)
        {
            this.database = database;
        }

        /// <summary>
        /// Marks the episodes as viewed for the current user.
        /// </summary>
        /// <param name="id">The episode id.</param>
        [HttpPut]
        public void Put(int id)
        {
            var user = this.database.Query<User>().First(x => x.Username == WebSecurity.CurrentUserName);
            var episode = this.database.Query<Episode>().First(x => x.EpisodeId == id);

            user.ViewedEpisodes.Add(episode);
            this.database.SaveChanges();
        }

        /// <summary>
        /// Marks the episodes as not viewed for the current user.
        /// </summary>
        /// <param name="id">The id of the episode.</param>
        [HttpDelete]
        public void Delete(int id)
        {
            var user = this.database.Query<User>().First(x => x.Username == WebSecurity.CurrentUserName);
            var episode = this.database.Query<Episode>().First(x => x.EpisodeId == id);

            user.ViewedEpisodes.Remove(episode);
            this.database.SaveChanges();
        }
    }
}