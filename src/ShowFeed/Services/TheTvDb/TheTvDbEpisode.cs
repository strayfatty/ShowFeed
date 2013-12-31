namespace ShowFeed.Services.TheTvDb
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The <c>TheTVDB</c> episode.
    /// </summary>
    [Serializable]
    [XmlRoot("Episode")]
    public class TheTvDbEpisode
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the season number.
        /// </summary>
        [XmlElement("SeasonNumber")]
        public int SeasonNumber { get; set; }

        /// <summary>
        /// Gets or sets the episode number.
        /// </summary>
        [XmlElement("EpisodeNumber")]
        public int EpisodeNumber { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [XmlElement("EpisodeName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [XmlElement("Overview")]
        public string Description { get; set; }

        /// <summary>
        /// Gets the first aired date.
        /// </summary>
        public DateTime? FirstAired
        {
            get
            {
                DateTime firstAired;
                if (DateTime.TryParse(this.FirstAiredString, out firstAired))
                {
                    return firstAired;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets or sets the first aired date as a string.
        /// </summary>
        [XmlElement("FirstAired")]
        public string FirstAiredString { get; set; }

        /// <summary>
        /// Gets or sets the image link.
        /// </summary>
        [XmlElement("filename")]
        public string ImageLink { get; set; }
    }
}