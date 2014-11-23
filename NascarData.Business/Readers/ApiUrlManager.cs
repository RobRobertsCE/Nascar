using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi.Readers
{
    public class ApiUrlManager
    {
        #region enums      
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
        const string ApiEndpointUrlTemplate = @"http://www.nascar.com/live/feeds/Series_{0}/{1}/{2}.json";
        
        //www.nascar.com/leaderboard/Series_1/2014/4319/3/leaderboard.json
        // 0 = series #
        // 1 = year
        // 2 = race id
        // 3 = session (1=practice, 2 = qualifying, 3 = race)
        // 4 = feed url name (leaderboard)
        const string ApiLeaderboardUrlTemplate = @"http://www.nascar.com/leaderboard/Series_{0}/{1}/{2}/{3}/{4}.json"; 
        #endregion

        #region public static methods
        public static string GetLeaderboardApiUrl(SeriesType seriesType, int raceId, string fourDigitYear, SessionType sessionType)
        {
            return string.Format(ApiLeaderboardUrlTemplate, (int)seriesType, fourDigitYear, raceId, (int)sessionType + 1, ((FeedName)ApiFeedType.Leaderboard).ToString());
        }
        public static string GetApiUrl(ApiFeedType feedType, SeriesType seriesType, int raceId)
        {
            if (ApiFeedType.Leaderboard == feedType)
            {
                string fourDigitYear = ApiUrlManager.GetSeason();
                SessionType sessionType = SessionType.Race;
                return ApiUrlManager.GetLeaderboardApiUrl(seriesType, raceId, fourDigitYear, sessionType);               
            }
            else
            {
                return String.Format(ApiEndpointUrlTemplate, (int)seriesType, raceId, ApiUrlManager.GetApiEndpointName(feedType));
            }
        } 
        #endregion

        #region private static methods
        private static string GetSeason()
        {
            return DateTime.Now.Year.ToString(); 
        }
        private static string GetApiEndpointName(ApiFeedType feedType)
        {
            return ((FeedName)feedType).ToString();
        }
        #endregion
    }
}
