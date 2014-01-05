namespace ShowFeed.Services
{
    using System.Collections.Generic;

    /// <summary>
    /// The update data.
    /// </summary>
    public class UpdateData
    {
        /// <summary>
        /// Gets or sets the update time.
        /// </summary>
        public int UpdateTime { get; set; }

        /// <summary>
        /// Gets or sets the updated series.
        /// </summary>
        public IEnumerable<ISeriesUpdateRecord> Series { get; set; }

        /// <summary>
        /// Gets or sets the updated episodes.
        /// </summary>
        public IEnumerable<IEpisodeUpdateRecord> Episodes { get; set; }
    }
}