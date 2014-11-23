namespace NascarApi.Readers
{
    using System;
    using NascarApi.Models.Weather;

    public sealed class WeatherModelEventArgs : ApiModelEventArgs<ResponseModel>
    {
        public WeatherModelEventArgs(ResponseModel model)
            : base(model)
        { }
    }
}
