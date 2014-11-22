namespace NascarApi.Readers
{
    public class QualifyingApiClient : ApiClient
    {
        public QualifyingApiClient(SeriesType seriesType, int raceId)
            : base(seriesType, raceId, ApiFeedType.LiveQualifying)
        { }
    }
}
