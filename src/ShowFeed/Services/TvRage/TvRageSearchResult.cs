namespace ShowFeed.Services.TvRage
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The <c>TVRage</c> search result.
    /// </summary>
    [Serializable]
    [XmlRoot("show")]
    public class TvRageSearchResult
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
        /// Gets or sets the link.
        /// </summary>
        [XmlElement("link")]
        public string Link { get; set; }
    }
}