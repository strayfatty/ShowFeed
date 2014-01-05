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
        IEnumerable<IBaseSeriesRecord> Search(string series);

        /// <summary>
        /// Gets the complete series details.
        /// </summary>
        /// <param name="seriesId">The series id.</param>
        /// <returns>The <see cref="SeriesDetails"/>.</returns>
        SeriesDetails GetDetails(int seriesId);

        /// <summary>
        /// Gets the update data.
        /// </summary>
        /// <param name="lastUpdate">The last time an update was run.</param>
        /// <returns>The <see cref="UpdateData"/>.</returns>
        UpdateData GetUpdateData(int lastUpdate);

        /// <summary>
        /// Gets the base series record.
        /// </summary>
        /// <param name="seriesId">The series id.</param>
        /// <returns>The <see cref="IBaseSeriesRecord"/>.</returns>
        IBaseSeriesRecord GetBaseSeriesRecord(int seriesId);

        /// <summary>
        /// Gets the base episode record.
        /// </summary>
        /// <param name="episodeId">The episode id.</param>
        /// <returns>The <see cref="IBaseEpisodeRecord"/>.</returns>
        IBaseEpisodeRecord GetBaseEpisodeRecord(int episodeId);
    }
}