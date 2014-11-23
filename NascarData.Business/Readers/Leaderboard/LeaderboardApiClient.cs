namespace NascarApi.Readers
{
    public class LeaderboardApiClient : ApiClient
    {
        public int Season { get; protected set; }
        public SessionType SessionType { get; protected set; }
        public LeaderboardApiClient(SeriesType seriesType, int raceId, int season, SessionType sessionType)
            : base(seriesType, raceId, season, sessionType)
        {
            this.Season = season;
            this.SessionType = sessionType;
        }
    }
}