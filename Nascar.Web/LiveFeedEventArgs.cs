using System;
using Nascar.Models;

namespace Nascar.Web
{
    public sealed class LiveFeedEventArgs 
        : FeedEventArgs
    {
        public LiveFeedModel LiveFeed { get; private set; }

        public LiveFeedEventArgs(LiveFeedModel liveFeedModel)
        {
            this.Arrived = DateTime.Now;
            this.LiveFeed = liveFeedModel;
        }
    }
}
