namespace ShowFeed.Services
{
    /// <summary>
    /// The base series record interface.
    /// </summary>
    public interface IBaseSeriesRecord
    {
        /// <summary>
        /// Gets or sets the series id.
        /// </summary>
        int SeriesId { get; set; }

        /// <summary>
        /// Gets or sets the IMDB id.
        /// </summary>
        string ImdbId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the banner link.
        /// </summary>
        string BannerLink { get; set; }

        /// <summary>
        /// Gets or sets the fan art link.
        /// </summary>
        string FanArtLink { get; set; }

        /// <summary>
        /// Gets or sets the poster link.
        /// </summary>
        string PosterLink { get; set; }
    }
}