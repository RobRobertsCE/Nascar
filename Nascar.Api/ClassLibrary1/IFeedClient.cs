using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nascar.Api.Models;

namespace Nascar.Api
{
    public interface IFeedClient : IDisposable 
    {
        SeriesName Series { get; }
        int RaceId { get; }

        string GetData();
    }
}