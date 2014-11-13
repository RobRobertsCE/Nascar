using System;
using Nascar.Api.Models;

namespace Nascar.Api
{
    public interface ILiveFeedProcessor
    {
        void ProcessLiveFeed(LiveFeedModel model);
        void Display();
    }
}
