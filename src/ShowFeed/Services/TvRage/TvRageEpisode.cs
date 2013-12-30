namespace ShowFeed.Services.TvRage
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The <c>TVRage</c> episode.
    /// </summary>
    [Serializable]
    [XmlRoot("episode")]
    public class TvRageEpisode
    {
        /// <summary>
        /// Gets or sets the season.
        /// </summary>
        [XmlElement("season")]
        public int Season { get; set; }

        /// <summary>
        /// Gets or sets the season number.
        /// </summary>
        [XmlElement("seasonnum")]
        public int SeasonNumber { get; set; }

        /// <summary>
        /// Gets or sets the episode number.
        /// </summary>
        [XmlElement("epnum")]
        public int EpisodeNumber { get; set; }

        /// <summary>
        /// Gets or sets the air date value.
        /// </summary>
        [XmlElement("airdate")]
        public string AirDateValue { get; set; }

        /// <summary>
        /// Gets the air date.
        /// </summary>
        public DateTime? AirDate
        {
            get
            {
                DateTime airDate;
                if (DateTime.TryParse(this.AirDateValue, out airDate))
                {
                    return airDate;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        [XmlElement("link")]
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        [XmlElement("screencap")]
        public string Image { get; set; }
    }
}