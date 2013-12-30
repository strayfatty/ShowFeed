namespace ShowFeed.Services.TvRage
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The <c>TVRage</c> season.
    /// </summary>
    [Serializable]
    [XmlRoot("Season")]
    public class TvRageSeason
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        [XmlAttribute("no")]
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the episodes.
        /// </summary>
        [XmlElement("episode")]
        public TvRageEpisode[] Episodes { get; set; }
    }
}