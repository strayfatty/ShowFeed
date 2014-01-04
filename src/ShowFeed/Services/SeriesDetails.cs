namespace ShowFeed.Services
{
    using System.Collections.Generic;

    /// <summary>
    /// The series details interface.
    /// </summary>
    public class SeriesDetails
    {
        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        public IBaseSeriesRecord Series { get; set; }

        /// <summary>
        /// Gets or sets the episodes.
        /// </summary>
        public IEnumerable<IBaseEpisodeRecord> Episodes { get; set; }
    }
}