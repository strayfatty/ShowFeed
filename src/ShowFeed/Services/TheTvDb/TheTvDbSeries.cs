namespace ShowFeed.Services.TheTvDb
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The <c>TheTVDB</c> series.
    /// </summary>
    [Serializable]
    [XmlRoot("Series")]
    public class TheTvDbSeries : IBaseSeriesRecord
    {
        /// <summary>
        /// Gets or sets the series id.
        /// </summary>
        [XmlElement("id")]
        public int SeriesId { get; set; }

        /// <summary>
        /// Gets or sets the IMDB id.
        /// </summary>
        [XmlElement("IMDB_ID")]
        public string ImdbId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [XmlElement("SeriesName")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [XmlElement("Overview")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the banner link.
        /// </summary>
        [XmlElement("banner")]
        public string BannerLink { get; set; }

        /// <summary>
        /// Gets or sets the fan art link.
        /// </summary>
        [XmlElement("fanart")]
        public string FanArtLink { get; set; }

        /// <summary>
        /// Gets or sets the poster link.
        /// </summary>
        [XmlElement("poster")]
        public string PosterLink { get; set; }
    }
}