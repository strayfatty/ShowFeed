namespace ShowFeed.Services
{
    /// <summary>
    /// The episode update data interface.
    /// </summary>
    public interface IEpisodeUpdateRecord
    {
        /// <summary>
        /// Gets or sets the episode id.
        /// </summary>
        int EpisodeId { get; set; }

        /// <summary>
        /// Gets or sets the series id.
        /// </summary>
        int SeriesId { get; set; }

        /// <summary>
        /// Gets or sets the update time.
        /// </summary>
        int UpdateTime { get; set; }
    }
}