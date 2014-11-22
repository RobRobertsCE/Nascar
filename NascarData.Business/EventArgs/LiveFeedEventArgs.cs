using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NascarApi.Models.LiveFeed;

namespace NascarApi
{
    public sealed class LiveFeedEventArgs : FeedEventArgs
    {
        public LiveFeedModel LiveFeed { get; private set; }

        public LiveFeedEventArgs(LiveFeedModel liveFeedModel)
        {
            this.Arrived = DateTime.Now;
            this.LiveFeed = liveFeedModel;
        }
    }
}
