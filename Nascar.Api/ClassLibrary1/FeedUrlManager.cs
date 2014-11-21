using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nascar.Api.Models;

namespace Nascar.Api
{
    public class FeedUrlManager
    {
        #region enums
        public enum SessionType
        {
            Practice,
            Qualifying,
            Race
        }
        public enum FeedType
        {
            Leaderboard,
            LiveFeed,
            LivePoints,
            LiveQualifying,
            LiveFlag,
            LiveWeather
        }
        enum FeedName
        {
            leaderboard,
            live_feed,
            live_points,
            live_qualifying,
            live_flag,
            live_weather
        } 
        #endregion

        #region consts
        // 0 = series #
        // 1 = race id
        // 2 = feed url name (leaderboard)
        const string LiveFeedUrlTemplate = @"http://www.nascar.com/live/feeds/Series_{0}/{1}/{2}.json";

        //www.nascar.com/leaderboard/Series_1/2014/4319/3/leaderboard.json
        // 0 = series #
        // 1 = year
        // 2 = race id
        // 3 = session (1=practice, 2 = qualifying, 3 = race)
        // 4 = feed url name (leaderboard)
        const string LiveLeaderboardUrlTemplate = @"http://www.nascar.com/leaderboard/Series_{0}/{1}/{2}/{3}/{4}.json"; 
        #endregion

        #region static methods
        public static string GetLeaderboardFeedUrl(SeriesName series, int race_id, int season, SessionType session)
        {
            return string.Format(LiveFeedUrlTemplate, (int)series, season, race_id, (int)session, ((FeedName)FeedType.Leaderboard).ToString());
        }
        public static string GetLiveFeedUrl(FeedType feed, SeriesName series, int race_id)
        {
            if (FeedType.Leaderboard == feed) throw new InvalidOperationException("Use GetLeaderboardFeedUrl for Leaderboard feed URL.");

            return String.Format(LiveFeedUrlTemplate, (int)series, race_id, ((FeedName)feed).ToString());
        } 
        #endregion
    }
}
