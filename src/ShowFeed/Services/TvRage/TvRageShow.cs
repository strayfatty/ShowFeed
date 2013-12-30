namespace ShowFeed.Services.TvRage
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The <c>TVRage</c> show.
    /// </summary>
    [Serializable]
    [XmlRoot("Show")]
    public class TvRageShow
    {
        /// <summary>
        /// Gets or sets the show id.
        /// </summary>
        [XmlElement("showid")]
        public int ShowId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the show link.
        /// </summary>
        [XmlElement("showlink")]
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        [XmlElement("image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the seasons.
        /// </summary>
        [XmlElement("Episodelist")]
        public TvRageEpisodeList EpisodeList { get; set; }
    }
}