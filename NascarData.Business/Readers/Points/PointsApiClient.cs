namespace NascarApi.Readers
{
    public class PointsApiClient : ApiClient
    {
        public PointsApiClient(SeriesType seriesType, int raceId)
            : base(seriesType, raceId, ApiFeedType.LivePoints)
        { }
    }
}

