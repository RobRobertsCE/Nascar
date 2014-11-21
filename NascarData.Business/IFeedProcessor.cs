using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NascarApi.Business
{
    public interface IFeedProcessor
    {
        int race_id { get; }
        int series_id { get;}

        void processFeedData(string feedData);
        void processFeedModel(NascarApi.Models.LiveFeed.LiveFeedModel model);

        void processLiveFlag(string liveFlagData);
        void processLiveFlagModel(NascarApi.Models.Flag.FlagModel model);
    }
}
