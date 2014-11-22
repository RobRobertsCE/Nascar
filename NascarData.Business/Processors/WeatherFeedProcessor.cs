namespace NascarApi.Processors
{
    using NascarApi.Models.Qualifying;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NascarApi.Models;
    using NascarApi.Models.Weather;

    public class WeatherFeedProcessor : FeedProcessor<ResponseModel>
    {
        public override ApiFeedType FeedType
        {
            get
            {
                return ApiFeedType.LiveWeather;
            }
        }

        public WeatherFeedProcessor(int season_id, int series_id, int race_id)
            : base(season_id, series_id, race_id)
        {

        }

        protected override void BeginProcessAsync(ResponseModel model)
        {

        }
    }
}
