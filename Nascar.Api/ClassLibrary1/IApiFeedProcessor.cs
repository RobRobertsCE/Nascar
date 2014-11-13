using System;

namespace Nascar.Api
{
    public interface IApiFeedProcessor
    {
        string LastFeedData { get; }

        void ProcessFeedData(string data);
    }
}
