namespace ShowFeed.Services.TvRage
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The TVRage episode list.
    /// </summary>
    [Serializable]
    [XmlRoot("Episodelist")]
    public class TvRageEpisodeList
    {
        /// <summary>
        /// Gets or sets the seasons.
        /// </summary>
        [XmlElement("Season")]
        public TvRageSeason[] Seasons { get; set; }

        /// <summary>
        /// Gets or sets the seasons.
        /// </summary>
        [XmlArray("Special")]
        [XmlArrayItem("episode")]
        public TvRageEpisode[] Specials { get; set; }
    }
}