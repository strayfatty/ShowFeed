namespace ShowFeed.Services.TheTvDb
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The <c>TheTVDB</c> search results.
    /// </summary>
    [Serializable]
    [XmlRoot("Data")]
    public class TheTvDbSearchResults
    {
        /// <summary>
        /// Gets or sets the series.
        /// </summary>
        [XmlElement("Series")]
        public TheTvDbSearchResult[] Series { get; set; }
    }
}