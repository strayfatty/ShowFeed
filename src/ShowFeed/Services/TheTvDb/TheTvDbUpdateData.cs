namespace ShowFeed.Services.TheTvDb
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The <c>TheTVDB</c> update data.
    /// </summary>
    [Serializable]
    [XmlRoot("Data")]
    public class TheTvDbUpdateData
    {
        /// <summary>
        /// Gets or sets the update time.
        /// </summary>
        [XmlAttribute("time")]
        public int UpdateTime { get; set; }

        /// <summary>
        /// Gets or sets the series update records.
        /// </summary>
        [XmlElement("Series")]
        public TheTvDbSeriesUpdateRecord[] Series { get; set; }

        /// <summary>
        /// Gets or sets the episode update records.
        /// </summary>
        [XmlElement("Episode")]
        public TheTvDbEpisodeUpdateRecord[] Episodes { get; set; }
    }
}