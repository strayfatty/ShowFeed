namespace ShowFeed.Services.TvRage
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Xml.Serialization;

    using ShowFeed.Models;

    /// <summary>
    /// The TVRage feed service.
    /// </summary>
    public class TvRageFeedService : ITvShowService
    {
        /// <summary>
        /// The search feed base url.
        /// </summary>
        private const string SearchFeed = "http://services.tvrage.com/feeds/search.php?show=";
        
        /// <summary>
        /// Searches for shows with a similar name.
        /// </summary>
        /// <param name="showName">The show name.</param>
        /// <returns>An array of <see cref="TvShow"/>.</returns>
        public TvShow[] Search(string showName)
        {
            var searchResult = DownloadFeed<TvRageSearchResults>(SearchFeed + showName);
            return searchResult.Results.Select(
                    x => new TvShow
                    {
                        SourceId = x.ShowId,
                        Name = x.Name,
                        SourceLink = x.Link
                    })
                .ToArray();
        }

        /// <summary>
        /// Downloads a feed.
        /// </summary>
        /// <typeparam name="T">The feed type.</typeparam>
        /// <param name="feed">The feed address.</param>
        /// <returns>The feed.</returns>
        private static T DownloadFeed<T>(string feed)
        {
            var webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            var response = webClient.DownloadString(feed);

            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(response))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}