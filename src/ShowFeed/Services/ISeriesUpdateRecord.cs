namespace ShowFeed.Services
{
    /// <summary>
    /// The series update data interface.
    /// </summary>
    public interface ISeriesUpdateRecord
    {
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