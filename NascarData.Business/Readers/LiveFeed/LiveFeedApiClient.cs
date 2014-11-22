namespace NascarApi.Readers
{
    public class LiveFeedApiClient : ApiClient
    {
        public LiveFeedApiClient(SeriesType seriesType, int raceId)
            : base(seriesType, raceId, ApiFeedType.LiveFeed)
        { }
    }
}
