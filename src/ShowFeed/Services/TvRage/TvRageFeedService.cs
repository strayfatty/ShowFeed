namespace ShowFeed.Services.TvRage
{
    using System;
    using System.Collections.Generic;
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
        /// The full show info feed base url.
        /// </summary>
        private const string FullShowInfoFeed = "http://services.tvrage.com/feeds/full_show_info.php?sid=";
  
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
        /// Gets the complete show details.
        /// </summary>
        /// <param name="showId">The show id.</param>
        /// <returns>The <see cref="TvShow"/>.</returns>
        public TvShow GetDetails(int showId)
        {
            var tvRageShow = DownloadFeed<TvRageShow>(FullShowInfoFeed + showId.ToString());

            var show = new TvShow();
            show.SourceId = tvRageShow.ShowId;
            show.SourceLink = tvRageShow.Link;
            show.SourceImageLink = tvRageShow.Image;
            show.Name = tvRageShow.Name;

            foreach (var tvRageSeason in tvRageShow.EpisodeList.Seasons)
            {
                foreach (var tvRageEpisode in tvRageSeason.Episodes)
                {
                    var episode = new TvEpisode();
                    episode.SourceLink = tvRageEpisode.Link;
                    episode.SourceImageLink = tvRageEpisode.Image;
                    episode.Season = tvRageSeason.Number;
                    episode.Index = tvRageEpisode.SeasonNumber;
                    episode.Title = tvRageEpisode.Title;
                    episode.Summary = null;
                    episode.AirDate = tvRageEpisode.AirDate;

                    show.Episodes.Add(episode);
                }
            }

            foreach (var tvRageEpisode in tvRageShow.EpisodeList.Specials)
            {
                var episode = new TvEpisode();
                episode.SourceLink = tvRageEpisode.Link;
                episode.SourceImageLink = tvRageEpisode.Image;
                episode.Season = tvRageEpisode.Season;
                episode.Index = 0;
                episode.Title = tvRageEpisode.Title;
                episode.Summary = null;
                episode.AirDate = tvRageEpisode.AirDate;

                show.Episodes.Add(episode);
            }

            return show;
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