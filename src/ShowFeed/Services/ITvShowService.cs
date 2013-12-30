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
    }
}
