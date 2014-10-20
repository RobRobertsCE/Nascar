using System;
using Nascar.Models;

namespace Nascar.Web
{
    interface IFeedClient
    {
        Series Series { get; }

        string GetData();
    }
}
