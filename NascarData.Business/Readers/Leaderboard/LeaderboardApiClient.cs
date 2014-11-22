namespace NascarApi.Readers
{
    public class LeaderboardApiClient : ApiClient
    {
        public LeaderboardApiClient(SeriesType seriesType, int raceId)
            : base(seriesType, raceId, ApiFeedType.Leaderboard)
        { }
    }
}