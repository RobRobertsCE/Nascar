namespace NascarApi.Readers
{
    using System;
    using NascarApi.Models.Weather;

    public sealed class WeatherModelEventArgs : ApiModelEventArgs<WeatherUndergroundModel>
    {
        public WeatherModelEventArgs(WeatherUndergroundModel model)
            : base(model)
        { }
    }
}
