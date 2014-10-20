using System;
using Nascar.Models;

namespace Nascar.Web
{
    interface IFeedClient
    {
        SeriesName Series { get; }

        string GetData();
    }
}
