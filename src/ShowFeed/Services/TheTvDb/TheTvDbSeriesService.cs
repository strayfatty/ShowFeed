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

    using ShowFeed.Controllers;
    using ShowFeed.Models;

    using StackExchange.Profiling;

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
        public IEnumerable<IBaseSeriesRecord> Search(string series)
        {
            using (MiniProfiler.Current.Step("search"))
            {
                const string BaseAddress = "http://thetvdb.com/api/GetSeries.php?seriesname={0}&language=en";
                var address = string.Format(BaseAddress, series);
                var result = DownloadXml<TheTvDbSearchResults>(address);
                return result.Series ?? new IBaseSeriesRecord[0];
            }
        }

        /// <summary>
        /// Gets the complete series details.
        /// </summary>
        /// <param name="seriesId">The series id.</param>
        /// <returns>The <see cref="SeriesDetails"/>.</returns>
        public SeriesDetails GetDetails(int seriesId)
        {
            using (MiniProfiler.Current.Step("get details"))
            {
                const string BaseAddress = "http://thetvdb.com/api/{0}/series/{1}/all/en.zip";
                var address = string.Format(BaseAddress, ConfigurationManager.AppSettings["TheTVDB.ApiKey"], seriesId);
                var result = DownloadZip<TheTvDbSeriesDetails>(address, "en.xml");
                return new SeriesDetails
                {
                    Series = result.Series,
                    Episodes = result.Episodes ?? new IBaseEpisodeRecord[0]
                };
            }
        }

        /// <summary>
        /// Gets the update data.
        /// </summary>
        /// <param name="lastUpdate">The last time an update was run.</param>
        /// <returns>The <see cref="UpdateData"/>.</returns>
        public UpdateData GetUpdateData(int lastUpdate)
        {
            using (MiniProfiler.Current.Step("get update data"))
            {
                string updateType = GetUpdateType(lastUpdate);
                const string BaseAddress = "http://thetvdb.com/api/{0}/updates/updates_{1}.zip";
                var address = string.Format(BaseAddress, ConfigurationManager.AppSettings["TheTVDB.ApiKey"], updateType);
                var result = DownloadZip<TheTvDbUpdateData>(address, string.Format("updates_{0}.xml", updateType));
                return new UpdateData
                {
                    UpdateTime = result.UpdateTime,
                    Series = (result.Series ?? new ISeriesUpdateRecord[0]).Where(x => x.UpdateTime > lastUpdate),
                    Episodes = (result.Episodes ?? new IEpisodeUpdateRecord[0]).Where(x => x.UpdateTime > lastUpdate)
                };
            }
        }

        /// <summary>
        /// Downloads a xml file.
        /// </summary>
        /// <typeparam name="T">The result type.</typeparam>
        /// <param name="address">The address.</param>
        /// <returns>The deserialized xml.</returns>
        private static T DownloadXml<T>(string address)
        {
            using (MiniProfiler.Current.Step("download"))
            using (var stream = OpenStream(address))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
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
            using (MiniProfiler.Current.Step("download"))
            using (var stream = OpenStream(address))
            using (var archive = new ZipArchive(stream))
            {
                var entry = archive.Entries.First(x => x.Name == filename);
                using (var entryStream = entry.Open())
                {
                    var serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(entryStream);
                }
            }
        }

        /// <summary>
        /// Opens a stream.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <returns>The stream.</returns>
        private static Stream OpenStream(string address)
        {
            using (MiniProfiler.Current.Step("open stream"))
            using (var client = new WebClient())
            {
                return client.OpenRead(address);
            }
        }

        /// <summary>
        /// Gets the update type, either day, week or month.
        /// </summary>
        /// <param name="lastUpdate">The last time an update was run.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static string GetUpdateType(int lastUpdate)
        {
            var timeSpan = DateTime.UtcNow - UpdatesController.Epoch.AddSeconds(lastUpdate);
            if (timeSpan.TotalHours < 24.0)
            {
                return "day";
            }

            if (timeSpan.TotalDays < 7.0)
            {
                return "week";
            }

            return "month";
        }
    }
}