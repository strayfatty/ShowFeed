namespace ShowFeed.Services.TvRage
{
    using System;

    using ShowFeed.Models;

    /// <summary>
    /// The TVRage feed service.
    /// </summary>
    public class TvRageFeedService : ITvShowService
    {
        /// <summary>
        /// Searches for shows with a similar name.
        /// </summary>
        /// <param name="showName">The show name.</param>
        /// <returns>An array of <see cref="TvShow"/>.</returns>
        public TvShow[] Search(string showName)
        {
            return new[]
            {
                new TvShow
                {
                    SourceId = 3333,
                    Name = "Doctor Who (2005)",
                    Description = string.Empty,
                    SourceLink = "...",
                },
                new TvShow
                {
                    SourceId = 3334,
                    Name = "Doctor Who",
                    Description = string.Empty,
                    SourceLink = "...",
                },
            };
        }
    }
}