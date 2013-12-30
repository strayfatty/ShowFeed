namespace ShowFeed.Services
{
    using ShowFeed.Models;

    /// <summary>
    /// The TV show service interface.
    /// </summary>
    public interface ITvShowService
    {
        /// <summary>
        /// Searches for shows with a similar name.
        /// </summary>
        /// <param name="showName">The show name.</param>
        /// <returns>An array of <see cref="TvShow"/>.</returns>
        TvShow[] Search(string showName);

        /// <summary>
        /// Gets the complete show details.
        /// </summary>
        /// <param name="showId">The show id.</param>
        /// <returns>The <see cref="TvShow"/>.</returns>
        TvShow GetDetails(int showId);
    }
}
