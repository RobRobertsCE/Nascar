using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi
{
    public interface IApiClient : IDisposable 
    {
        SeriesType Series { get; }
        int RaceId { get; }
        ApiFeedType Feed { get; }

        string GetData();
        void BeginGetDataAsync();
    }
}