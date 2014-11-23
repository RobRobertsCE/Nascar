namespace NascarApi.Readers
{
    using System;
    using NascarApi.Models.LiveFeed;

    public sealed class LiveFeedModelEventArgs : ApiModelEventArgs<LiveFeedModel>
    {
        public LiveFeedModelEventArgs(LiveFeedModel model) : base(model)
        {   }
    }
}
