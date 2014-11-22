namespace NascarApi.Readers
{
    public class WeatherApiClient : ApiClient
    {
        public WeatherApiClient(SeriesType seriesType, int raceId)
            : base(seriesType, raceId, ApiFeedType.LiveWeather)
        { }
    }
}
