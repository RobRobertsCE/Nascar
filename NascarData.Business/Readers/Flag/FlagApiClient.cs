namespace NascarApi.Readers
{
    public class FlagApiClient : ApiClient
    {
        public FlagApiClient(SeriesType seriesType, int raceId)
            : base(seriesType, raceId, ApiFeedType.LiveFlag)
        { }
    }
}
