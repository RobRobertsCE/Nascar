using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nascar.Api.Models;

namespace Nascar.Api
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
