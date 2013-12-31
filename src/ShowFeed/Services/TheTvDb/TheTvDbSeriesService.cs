namespace ShowFeed.Services.TheTvDb
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.IO.Compression;
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

            if (result.Series == null)
            {
                return new Series[0];
            }

            return result.Series.Select(
                x => new Series
                {
                    SeriesId = x.SeriesId,
                    ImdbId = x.ImdbId,
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
            const string BaseAddress = "http://thetvdb.com/api/{0}/series/{1}/all/en.zip";
            var address = string.Format(BaseAddress, ConfigurationManager.AppSettings["TheTVDB.ApiKey"], seriesId);

            var result = DownloadZip<TheTvDbSeriesDetails>(address, "en.xml");

            var series = new Series();
            series.SeriesId = result.Series.Id;
            series.ImdbId = result.Series.ImdbId;
            series.Name = result.Series.Name;
            series.Description = result.Series.Description;
            series.BannerLink = result.Series.BannerLink;
            series.FanArtLink = result.Series.FanArtLink;
            series.PosterLink = result.Series.PosterLink;

            if (result.Episodes != null)
            {
                series.Episodes = result.Episodes.Select(
                    x => new Episode
                        {
                            EpisodeId = x.Id,
                            SeasonNumber = x.SeasonNumber,
                            EpisodeNumber = x.EpisodeNumber,
                            Name = x.Name,
                            Description = x.Description,
                            FirstAired = x.FirstAired,
                            ImageLink = x.ImageLink
                        })
                    .ToList();
            }

            return series;
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

        /// <summary>
        /// Downloads a zip file and extracts one contained file.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="address">The address.</param>
        /// <param name="filename">The file to extract.</param>
        /// <returns>The deserialized xml.</returns>
        private static T DownloadZip<T>(string address, string filename)
        {
            var webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;

            using (var fileStream = webClient.OpenRead(address))
            using (var zipArchive = new ZipArchive(fileStream))
            {
                var zipEntry = zipArchive.Entries.First(x => x.Name == filename);
                using (var entryStream = zipEntry.Open())
                {
                    var serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(entryStream);
                }
            }
        }
    }
}