namespace ShowFeed.Services.TheTvDb
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The <c>TheTVDB</c> series.
    /// </summary>
    [Serializable]
    [XmlRoot("Series")]
    public class TheTvDbSeries
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [XmlElement("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the IMDB id.
        /// </summary>
        [XmlElement("IMDB_ID")]
        public virtual string ImdbId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [XmlElement("SeriesName")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [XmlElement("Overview")]
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets the banner link.
        /// </summary>
        [XmlElement("banner")]
        public virtual string BannerLink { get; set; }

        /// <summary>
        /// Gets or sets the fan art link.
        /// </summary>
        [XmlElement("fanart")]
        public virtual string FanArtLink { get; set; }

        /// <summary>
        /// Gets or sets the poster link.
        /// </summary>
        [XmlElement("poster")]
        public virtual string PosterLink { get; set; }
    }
}