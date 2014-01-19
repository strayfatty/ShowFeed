namespace ShowFeed.Services.TheTvDb
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The <c>TheTVDB</c> series update record.
    /// </summary>
    [Serializable]
    [XmlRoot("Series")]
    public class TheTvDbSeriesUpdateRecord : ISeriesUpdateRecord
    {
        /// <summary>
        /// Gets or sets the series id.
        /// </summary>
        [XmlElement("id")]
        public int SeriesId { get; set; }

        /// <summary>
        /// Gets or sets the update time.
        /// </summary>
        [XmlElement("time")]
        public int UpdateTime { get; set; }
    }
}