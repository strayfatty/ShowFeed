namespace ShowFeed.Services.TheTvDb
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml.Serialization;

    using ShowFeed.Models;

    /// <summary>
    /// The <c>TheTVDB</c> series service.
    /// </summary>
    public class TheTvDbSeriesService : ISeriesService
    {
        /// <summary>
        /// Searches for series with a similar name.
        /// </summary>
        /// <param name="series">The series name.</param>
        /// <returns>A list of <see cref="Series"/>.</returns>
        public IEnumerable<Series> Search(string series)
        {
            const string BaseAddress = "http://thetvdb.com/api/GetSeries.php?seriesname={0}&language=en";
            var address = string.Format(BaseAddress, series);
            var result = DownloadXml<TheTvDbSearchResults>(address);

            return result.Series.Select(
                x => new Series
                {
                    SeriesId = x.SeriesId,
                    Name = x.Name,
                    Description = x.Description,
                });
        }

        /// <summary>
        /// Gets the complete series details.
        /// </summary>
        /// <param name="seriesId">The series id.</param>
        /// <returns>The <see cref="Series"/>.</returns>
        public Series GetDetails(int seriesId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Downloads a xml file.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="address">The address.</param>
        /// <returns>The deserialized xml.</returns>
        private static T DownloadXml<T>(string address)
        {
            var webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            var response = webClient.DownloadString(address);

            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(response))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}