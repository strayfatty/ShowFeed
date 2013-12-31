namespace ShowFeed.Services.TheTvDb
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The <c>TheTVDB</c> series details.
    /// </summary>
    [Serializable]
    [XmlRoot("Data")]
    public class TheTvDbSeriesDetails
    {
        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        [XmlElement("Series")]
        public TheTvDbSeries Series { get; set; }

        /// <summary>
        /// Gets or sets the episodes.
        /// </summary>
        [XmlElement("Episode")]
        public TheTvDbEpisode[] Episodes { get; set; }
    }
}