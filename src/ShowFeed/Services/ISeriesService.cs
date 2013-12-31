namespace ShowFeed.Services
{
    using System.Collections.Generic;

    using ShowFeed.Models;

    /// <summary>
    /// The series service interface.
    /// </summary>
    public interface ISeriesService
    {
        /// <summary>
        /// Searches for series with a similar name.
        /// </summary>
        /// <param name="series">The series name.</param>
        /// <returns>A list of <see cref="Series"/>.</returns>
        IEnumerable<Series> Search(string series);

        /// <summary>
        /// Gets the complete series details.
        /// </summary>
        /// <param name="seriesId">The series id.</param>
        /// <returns>The <see cref="Series"/>.</returns>
        Series GetDetails(int seriesId);
    }
}