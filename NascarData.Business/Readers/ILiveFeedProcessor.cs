using System;
using Nascar.Api.Models;

namespace NascarApi.Readers
{
    public interface ILiveFeedProcessor
    {
        void ProcessLiveFeed(LiveFeedModel model);
        void Display();
    }
}
