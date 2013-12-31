﻿namespace ShowFeed.Services.TheTvDb
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The <c>TheTVDB</c> search result.
    /// </summary>
    [Serializable]
    [XmlRoot("Series")]
    public class TheTvDbSearchResult
    {
        /// <summary>
        /// Gets or sets the series id.
        /// </summary>
        [XmlElement("seriesid")]
        public int SeriesId { get; set; }

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
    }
}