using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi.Readers
{
    class ApiClientFactory
    {
        public static IApiClient GetApiLeaderboardClient(SeriesType seriesType, int raceId, int season, SessionType sessionType)
        {
            return new LeaderboardApiClient(seriesType, raceId, season, sessionType);
        }

        public static IApiClient GetApiClient(SeriesType seriesType, int raceId, ApiFeedType feedType)
        {
            IApiClient client = null;

            switch (feedType)
            {
                case ApiFeedType.Leaderboard:
                    {
                        throw new InvalidOperationException("Use GetApiLeaderboardClient for leaderboard feed.");
                    }
                case ApiFeedType.LiveFeed:
                    {
                        client = new LiveFeedApiClient(seriesType, raceId);
                        break;
                    }
                case ApiFeedType.LiveFlag:
                    {
                        client = new FlagApiClient(seriesType, raceId);
                        break;
                    }
                case ApiFeedType.LivePoints:
                    {
                        client = new PointsApiClient(seriesType, raceId);
                        break;
                    }
                case ApiFeedType.LiveQualifying:
                    {
                        client = new QualifyingApiClient(seriesType, raceId);
                        break;
                    }
                case ApiFeedType.LiveWeather:
                    {
                        client = new WeatherApiClient(seriesType, raceId);
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Unrecognized FeedType: {0}", feedType.ToString());
                        break;
                    }
            }
            return client;
        }
    }
}
