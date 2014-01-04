namespace ShowFeed.Services
{
    using System;

    /// <summary>
    /// The base episode record interface.
    /// </summary>
    public interface IBaseEpisodeRecord
    {
        /// <summary>
        /// Gets or sets the episode id.
        /// </summary>
        int EpisodeId { get; set; }

        /// <summary>
        /// Gets or sets the season number.
        /// </summary>
        int SeasonNumber { get; set; }

        /// <summary>
        /// Gets or sets the episode number.
        /// </summary>
        int EpisodeNumber { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets the first aired date.
        /// </summary>
        DateTime? FirstAired { get; }

        /// <summary>
        /// Gets or sets the image link.
        /// </summary>
        string ImageLink { get; set; }
    }
}