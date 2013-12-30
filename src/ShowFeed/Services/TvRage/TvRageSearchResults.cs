namespace ShowFeed.Services.TvRage
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The <c>TVRage</c> search results.
    /// </summary>
    [Serializable]
    [XmlRoot("Results")]
    public class TvRageSearchResults
    {
        /// <summary>
        /// Gets or sets the shows.
        /// </summary>
        [XmlElement("show")]
        public TvRageSearchResult[] Results { get; set; }
    }
}