namespace ShowFeed.Services.TheTvDb
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The <c>TheTVDB</c> episode update record.
    /// </summary>
    [Serializable]
    [XmlRoot("Episode")]
    public class TheTvDbEpisodeUpdateRecord : IEpisodeUpdateRecord
    {
        /// <summary>
        /// Gets or sets the episode id.
        /// </summary>
        [XmlElement("id")]
        public int EpisodeId { get; set; }

        /// <summary>
        /// Gets or sets the series id.
        /// </summary>
        [XmlElement("Series")]
        public int SeriesId { get; set; }

        /// <summary>
        /// Gets or sets the update time.
        /// </summary>
        [XmlElement("time")]
        public int UpdateTime { get; set; }
    }
}