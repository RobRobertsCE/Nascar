using System;
using Nascar.Models;

namespace Nascar.Web
{
    interface IFeedClient : IDisposable 
    {
        SeriesName Series { get; }

        string GetData();
    }
}
