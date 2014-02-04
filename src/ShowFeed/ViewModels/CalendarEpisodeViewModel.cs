namespace ShowFeed.ViewModels
{
    using System;

    /// <summary>
    /// The calendar episode view model.
    /// </summary>
    public class CalendarEpisodeViewModel
    {
        /// <summary>
        /// Gets or sets the series id.
        /// </summary>
        public int SeriesId { get; set; }

        /// <summary>
        /// Gets or sets the series name.
        /// </summary>
        public string SeriesName { get; set; }

        /// <summary>
        /// Gets or sets the season number.
        /// </summary>
        public int SeasonNumber { get; set; }

        /// <summary>
        /// Gets or sets the episode number.
        /// </summary>
        public int EpisodeNumber { get; set; }

        /// <summary>
        /// Gets or sets the episode name.
        /// </summary>
        public string EpisodeName { get; set; }

        /// <summary>
        /// Gets or sets the first aired.
        /// </summary>
        public DateTime FirstAired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// the episode is already viewed.
        /// </summary>
        public bool Viewed { get; set; }

        /// <summary>
        /// Gets the episode description.
        /// </summary>
        public string EpisodeDescription
        {
            get
            {
                var head = "Special";
                if (this.SeasonNumber != 0)
                {
                    head = string.Format("S{0:00}E{1:00}", this.SeasonNumber, this.EpisodeNumber);
                }

                return head + " - " + this.EpisodeName;
            }
        }
    }
}